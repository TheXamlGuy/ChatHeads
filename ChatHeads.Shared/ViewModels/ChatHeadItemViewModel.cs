using ChatHeads.Shared.Helpers;
using ChatHeads.Shared.Notifications;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadItemViewModel : ObservableObject, INotificationHandler
    {
        public ChatHeadItemViewModel(INotificationSubscriber notificationSubscriber)
        {
            notificationSubscriber.Subscribe(this);
        }

        public string Group { get; set; }
        public uint Id { get; set; }
        public string ImageSource { get; set; }
        public int NotificationBadgeCount { get; set; } 

        public void OnHandleChatHeadNotification(NotificationEventArgs args)
        {
            if (args.Notification.Group == Group)
            {
                args.Handled = true;
                NotificationBadgeCount++;
            }
        }
    }
}
