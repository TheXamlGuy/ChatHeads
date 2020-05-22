using ChatHeads.Shared.ChatHeadNotifications;

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