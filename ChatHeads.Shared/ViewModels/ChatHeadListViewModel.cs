using ChatHeads.Data;
using ChatHeads.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml.Serialization;
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
                using var dbContext = new NotificationsContext();
                var notification = await dbContext.Notification.FirstOrDefaultAsync(x => x.Id == args.UserNotificationId);
                if (notification == null) return;

                var serializer = new XmlSerializer(typeof(Toast));
                using (var reader = new StringReader(notification?.Payload))
                {
                    var test = (Toast)serializer.Deserialize(reader);

                    var vm = new ChatHeadItemViewModel();
                    vm.ImageSource = test?.Visual?.Binding?.Image.Src;

                    Add(vm);
                }
            }
        }
    }
}