using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyoutPresenter : ItemsControl
    {
        public ChatHeadFlyoutPresenter() => DefaultStyleKey = typeof(ChatHeadFlyoutPresenter);

        protected override DependencyObject GetContainerForItemOverride() => new ChatHeadFlyoutItem();

        protected override bool IsItemItsOwnContainerOverride(object item) => item is ChatHeadFlyoutItem;
    }
}