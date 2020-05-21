using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace ChatHeads.UI.Helpers
{
    public class ScreenHelper
    {
        private const int CCHDEVICENAME = 32;
        private const int PRIMARY_MONITOR = unchecked((int)0xBAADF00D);
        private const int SM_CMONITORS = 80;
        private static readonly bool _multiMonitorSupport;
        private readonly IntPtr _monitorHandle;

        static ScreenHelper() => _multiMonitorSupport = GetSystemMetrics(SM_CMONITORS) != 0;

        internal ScreenHelper(IntPtr monitorHandle)
        {
            if (!_multiMonitorSupport || monitorHandle == (IntPtr)PRIMARY_MONITOR)
            {
                Bounds = SystemInformationHelper.VirtualScreen;
                Primary = true;
                DeviceName = "DISPLAY";
            }
            else
            {
                var monitorData = GetMonitorData(monitorHandle);

                Bounds = new Rect(monitorData.MonitorRect.Left, monitorData.MonitorRect.Top, monitorData.MonitorRect.Right - monitorData.MonitorRect.Left, monitorData.MonitorRect.Bottom - monitorData.MonitorRect.Top);
                Primary = (monitorData.Flags & (int)MonitorFlag.MONITOR_DEFAULTTOPRIMARY) != 0;
                DeviceName = monitorData.DeviceName;
            }

            _monitorHandle = monitorHandle;
        }

        internal enum MonitorFlag : uint
        {
            MONITOR_DEFAULTTONULL = 0,
            MONITOR_DEFAULTTOPRIMARY = 1,
            MONITOR_DEFAULTTONEAREST = 2
        }

        public Rect Bounds { get; }

        public string DeviceName { get; }

        public bool Primary { get; }

        public Rect WorkingArea => GetWorkingArea();

        public static ScreenHelper FromHandle(IntPtr handle) => _multiMonitorSupport ? new ScreenHelper(MonitorFromWindow(handle, MonitorFlag.MONITOR_DEFAULTTONEAREST)) : new ScreenHelper((IntPtr)PRIMARY_MONITOR);

        public override bool Equals(object obj)
        {
            if (obj is ScreenHelper monitor)
            {
                if (_monitorHandle == monitor._monitorHandle)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode() => (int)_monitorHandle;

        [DllImport("user32.dll", EntryPoint = "GetMonitorInfo", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetMonitorInfoEx(IntPtr hMonitor, ref MonitorData lpmi);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr handle, MonitorFlag flags);
        private MonitorData GetMonitorData(IntPtr monitorHandle)
        {
            var monitorData = new MonitorData();
            monitorData.Size = Marshal.SizeOf(monitorData);

            GetMonitorInfoEx(monitorHandle, ref monitorData);
            return monitorData;
        }

        private Rect GetWorkingArea()
        {
            if (!_multiMonitorSupport || _monitorHandle == (IntPtr)PRIMARY_MONITOR)
            {
                return SystemInformationHelper.WorkingArea;
            }

            var monitorData = GetMonitorData(_monitorHandle);
            return new Rect(monitorData.WorkAreaRect.Left, monitorData.WorkAreaRect.Top, monitorData.WorkAreaRect.Right - monitorData.WorkAreaRect.Left, monitorData.WorkAreaRect.Bottom - monitorData.WorkAreaRect.Top);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MonitorData
        {
            public int Size;
            public NativeRect MonitorRect;
            public NativeRect WorkAreaRect;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;
        }
    }
}
