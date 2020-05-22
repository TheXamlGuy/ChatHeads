using ChatHeads.Shared.ChatHeadNotifications;
using ChatHeads.Shared.Helpers;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadItemViewModel : ObservableObject, IChatHeadNotificationHandler
    {
        public uint GroupId { get; set; }
        public uint Id { get; set; }
        public string ImageSource { get; set; }

        public ChatHeadItemViewModel(IChatHeadNotificationSubscriber groupNotificationSubscriber)
        {
            groupNotificationSubscriber.Subscribe(this);
        }

        public void OnHandleChatHeadNotification(ChatHeadNotificationEventArgs args)
        {
            if (args.GroupId == GroupId)
            {
                args.Handled = true;
            }
        }
    }
}
