using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyoutItem : ContentControl
    {
        public static readonly DependencyProperty NotificationBadgeProperty =
            DependencyProperty.Register(nameof(NotificationBadge),
                typeof(object), typeof(ChatHeadFlyoutItem));

        public static readonly DependencyProperty NotificationBadgeTemplateProperty =
            DependencyProperty.Register(nameof(NotificationBadgeTemplate),
                typeof(DataTemplate), typeof(ChatHeadFlyoutItem));

        public ChatHeadFlyoutItem() => DefaultStyleKey = typeof(ChatHeadFlyoutItem);

        public object NotificationBadge
        {
            get => GetValue(NotificationBadgeProperty);
            set => SetValue(NotificationBadgeProperty, value);
        }

        public DataTemplate NotificationBadgeTemplate
        {
            get => (DataTemplate)GetValue(NotificationBadgeTemplateProperty);
            set => SetValue(NotificationBadgeTemplateProperty, value);
        }
    }
}
