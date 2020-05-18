using System.Runtime.InteropServices;
using System.Windows;

namespace ChatHeads.UI.Helpers
{
    public static class SystemInformationHelper
    {
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const int SPI_GETWORKAREA = 48;

        public static Rect VirtualScreen => GetVirtualScreen();

        public static Rect WorkingArea => GetWorkingArea();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeRect rc, int nUpdate);

        private static Rect GetVirtualScreen()
        {
            var size = new Size(GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
            return new Rect(0, 0, size.Width, size.Height);
        }

        private static Rect GetWorkingArea()
        {
            var rect = new NativeRect();
            SystemParametersInfo(SPI_GETWORKAREA, 0, ref rect, 0);
            return new Rect(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }
    }
}
