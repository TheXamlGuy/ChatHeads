using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ChatHeads.UI.Controls
{
    internal class ChatHeadFlyoutHost : Window
    {
        public ChatHeadFlyoutHost()
        {
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            ShowActivated = true;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            Background = new SolidColorBrush(Colors.Transparent);
            Topmost = true;
        }

        protected override void OnMouseDown(MouseButtonEventArgs args) => DragMove();
    }
}
