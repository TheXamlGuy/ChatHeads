using System.Windows;

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
            SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
