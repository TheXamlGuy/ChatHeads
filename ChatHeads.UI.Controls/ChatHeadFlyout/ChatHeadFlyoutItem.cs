using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyoutItem : ContentControl
    {
        public static readonly DependencyProperty NumericBadgeProperty =
            DependencyProperty.Register(nameof(NumericBadge),
                typeof(object), typeof(ChatHeadFlyoutItem));

        public static readonly DependencyProperty NumericBadgeTemplateProperty =
            DependencyProperty.Register(nameof(NumericBadgeTemplate),
                typeof(DataTemplate), typeof(ChatHeadFlyoutItem));

        public ChatHeadFlyoutItem() => DefaultStyleKey = typeof(ChatHeadFlyoutItem);

        public object NumericBadge
        {
            get => GetValue(NumericBadgeProperty);
            set => SetValue(NumericBadgeProperty, value);
        }

        public DataTemplate NumericBadgeTemplate
        {
            get => (DataTemplate)GetValue(NumericBadgeTemplateProperty);
            set => SetValue(NumericBadgeTemplateProperty, value);
        }
    }
}
