using ChatHeads.Shared.Notifications;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadListViewModel : ListViewModel<ChatHeadItemViewModel>, IChatHeadNotificationHandler
    {
        public void OnHandleChatHeadNotification(ChatHeadNotificationEventArgs args)
        {
            args.Handled = true;
        }
    }
}