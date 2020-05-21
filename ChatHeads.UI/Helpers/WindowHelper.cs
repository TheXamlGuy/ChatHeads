using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ChatHeads.UI.Helpers
{
    public class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, out NativeRect lpRect);

        public static Rect GetBounds(Window window)
        {
            var handle = new WindowInteropHelper(window).Handle;
            if (GetWindowRect(new HandleRef(window, handle), out var rect))
            {
                return new Rect
                {
                    X = rect.Left,
                    Y = rect.Top,
                    Width = rect.Right - rect.Left,
                    Height = rect.Bottom - rect.Top
                };
            }

            return Rect.Empty;
        }
    }
}
