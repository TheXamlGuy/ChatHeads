using ChatHeads.Shared.Mappings;
using ChatHeads.Shared.Models;
using ChatHeads.Shared.Notifications;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadListViewModel : ListViewModel<ChatHeadItemViewModel>, INotificationHandler
    {
        private readonly IMapping _mapping;

        public ChatHeadListViewModel(INotificationSubscriber notificationSubscriber, IMapping mapping)
        {
            _mapping = mapping;
            notificationSubscriber.Subscribe(this);
        }

        public void OnHandleChatHeadNotification(NotificationEventArgs args)
        {
            args.Handled = true;

            var item = _mapping.Map<Notification, ChatHeadItemViewModel>(args.Notification);
            Add(item);
        }
    }
}