using System;
using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    internal class ChatHeadFlyoutPresenter : ItemsControl
    {
        public static readonly DependencyProperty ItemContainerTemplateSelectorProperty =
            DependencyProperty.Register(nameof(ItemContainerTemplateSelector),
                typeof(ItemContainerTemplateSelector), typeof(ChatHeadFlyoutPresenter),
                new PropertyMetadata(new ChatHeadFlyoutPresenterTemplateSelector()));

        public static readonly DependencyProperty UsesItemContainerTemplateProperty =
            DependencyProperty.Register(nameof(UsesItemContainerTemplate),
                typeof(bool), typeof(ChatHeadFlyoutPresenter));

        private object _currentItem;

        internal ChatHeadFlyout Owner;

        public ChatHeadFlyoutPresenter() => DefaultStyleKey = typeof(ChatHeadFlyoutPresenter);

        public ItemContainerTemplateSelector ItemContainerTemplateSelector
        {
            get => (ItemContainerTemplateSelector)GetValue(ItemContainerTemplateSelectorProperty);
            set => SetValue(ItemContainerTemplateSelectorProperty, value);
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

            var dataTemplate = ItemContainerTemplateSelector.SelectTemplate(currentItem, this);
            if (dataTemplate == null) return new ChatHeadFlyoutItem();

            var itemContainer = dataTemplate.LoadContent();
            if (itemContainer is ChatHeadFlyoutItem)
                return itemContainer;
            throw new InvalidOperationException(nameof(itemContainer));
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            var currentItem = item is ChatHeadFlyoutItem;
            if (!currentItem) _currentItem = item;

            return currentItem;
        }
    }
}