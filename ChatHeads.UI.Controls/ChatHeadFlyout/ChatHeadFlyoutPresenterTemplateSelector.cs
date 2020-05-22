using System.Windows;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    internal class ChatHeadFlyoutPresenterTemplateSelector : ItemContainerTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, ItemsControl parent)
        {
            var flyout = parent as ChatHeadFlyoutPresenter;
            var itemType = item.GetType();
            {
                var resourceKey = new ItemContainerTemplateKey(itemType);
                {
                    var template = flyout?.Owner?.TryFindResource(resourceKey);
                    if (template != null) return template as DataTemplate;
                }
            }

            return null;
        }
    }
}
