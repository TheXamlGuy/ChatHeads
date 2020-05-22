using ChatHeads.Shared.Models;

namespace ChatHeads.Shared.Notifications
{
    public class ChatHeadNotificationEventArgs
    {
        public Notification Notification { get; internal set; }
        public bool Handled { get; set; }
    }
}
