using System.Windows;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyout : FrameworkElement
    {
        private readonly ChatHeadFlyoutHost _host;

        public ChatHeadFlyout()
        {
            _host = new ChatHeadFlyoutHost();
        }

        public void Show()
        {
            _host.Show();
        }

        public void Hide()
        {
            _host.Hide();
        }
    }
}