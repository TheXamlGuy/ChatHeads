using System.Runtime.InteropServices;
using System.Windows;

namespace ChatHeads.UI.Helpers
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeRect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public static implicit operator Rect(NativeRect rect)
        {
            if (rect.Right - rect.Left < 0 || rect.Bottom - rect.Top < 0)
            {
                return new Rect(rect.Left, rect.Top, 0, 0);
            }

            return new Rect(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        public static implicit operator NativeRect(Rect rect)
        {
            return new NativeRect
            {
                Left = (int)rect.Left,
                Top = (int)rect.Top,
                Right = (int)rect.Right,
                Bottom = (int)rect.Bottom
            };
        }
    }
}