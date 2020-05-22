using ChatHeads.Shared.Helpers;
using ChatHeads.Shared.Notifications;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadItemViewModel : ObservableObject, IChatHeadNotification
    {
        public uint GroupId { get; set; }
        public uint Id { get; set; }
        public string ImageSource { get; set; }

        public ChatHeadItemViewModel(IChatHeadNotifier notifier)
        {
            notifier.Subscribe(this);
        }

        public void OnNotificationChanged()
        {

        }
    }
}
