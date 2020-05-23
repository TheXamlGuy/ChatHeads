using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ChatHeads.UI.Controls
{
    public class ItemContainerTemplateCollection : ObservableCollection<ItemContainerTemplate>
    {

    }
    //internal class ChatHeadFlyoutPresenterTemplateSelector : ItemContainerTemplateSelector
    //{
    //    public override DataTemplate SelectTemplate(object item, ItemsControl parent)
    //    {
    //        var flyout = parent as ChatHeadFlyoutPresenter;
    //        var itemType = item.GetType();
    //        {
    //            var resourceKey = new ItemContainerTemplateKey(itemType);

    //            var template = flyout?.Owner?.TryFindResource(resourceKey);
    //            if (template != null) return template as DataTemplate;
    //        }

    //        return null;
    //    }
    //}
}
