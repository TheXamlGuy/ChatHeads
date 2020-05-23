using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    internal class ChatHeadFlyoutPresenter : ItemsControl
    {
        public static readonly DependencyProperty ItemContainerTemplateCollectionProperty =
            DependencyProperty.Register(nameof(ItemContainerTemplateCollection),
                typeof(ItemContainerTemplateCollection), typeof(ChatHeadFlyoutPresenter));

        public static readonly DependencyProperty UsesItemContainerTemplateProperty =
            DependencyProperty.Register(nameof(UsesItemContainerTemplate),
                typeof(bool), typeof(ChatHeadFlyoutPresenter));

        private object _currentItem;

        internal ChatHeadFlyout Owner;

        public ChatHeadFlyoutPresenter() => DefaultStyleKey = typeof(ChatHeadFlyoutPresenter);

        public ItemContainerTemplateCollection ItemContainerTemplateCollection
        {
            get => (ItemContainerTemplateCollection)GetValue(ItemContainerTemplateCollectionProperty);
            set => SetValue(ItemContainerTemplateCollectionProperty, value);
        }

        public bool UsesItemContainerTemplate
        {
            get => (bool)GetValue(UsesItemContainerTemplateProperty);
            set => SetValue(UsesItemContainerTemplateProperty, value);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var currentItem = _currentItem;
            _currentItem = null;

            if (!UsesItemContainerTemplate) return new ChatHeadFlyoutItem();

            var itemType = currentItem.GetType();

            var dataTemplate = ItemContainerTemplateCollection.FirstOrDefault(x => x.DataType == (object)itemType);
            if (dataTemplate == null) return new ChatHeadFlyoutItem();

            var itemContainer = dataTemplate.LoadContent();
            if (itemContainer is ChatHeadFlyoutItem)
                return itemContainer;
            throw new InvalidOperationException(nameof(currentItem));
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            var currentItem = item is ChatHeadFlyoutItem;
            if (!currentItem) _currentItem = item;

            return currentItem;
        }
    }
}