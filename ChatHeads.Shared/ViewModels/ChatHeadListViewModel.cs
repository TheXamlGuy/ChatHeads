using ChatHeads.Data;
using Microsoft.EntityFrameworkCore;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.ViewModels
{

    public class ChatHeadListViewModel : ListViewModel<ChatHeadItemViewModel>
    {
        public ChatHeadListViewModel()
        {
            var listener = UserNotificationListener.Current;
            listener.NotificationChanged += ListenerOnNotificationChanged;
        }

        private async void ListenerOnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
        {
            if (args.ChangeKind == UserNotificationChangedKind.Added)
            {
                using (var dbContext = new NotificationsContext())
                {
                    var notification = await dbContext.Notification.FirstOrDefaultAsync(x => x.Id == args.UserNotificationId);
                    Add(new ChatHeadItemViewModel());
                }
            }
        }
    }
}