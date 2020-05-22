using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyoutItem : ContentControl
    {
        public static readonly DependencyProperty NotificationCountProperty =
            DependencyProperty.Register(nameof(NotificationCount),
                typeof(int), typeof(ChatHeadFlyoutItem));

        public ChatHeadFlyoutItem() => DefaultStyleKey = typeof(ChatHeadFlyoutItem);

        public int NotificationCount
        {
            get => (int)GetValue(NotificationCountProperty);
            set => SetValue(NotificationCountProperty, value);
        }
    }
}
