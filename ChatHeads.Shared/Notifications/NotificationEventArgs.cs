using ChatHeads.Shared.Models;

namespace ChatHeads.Shared.Notifications
{
    public class NotificationEventArgs
    {
        public Notification Notification { get; internal set; }
        public bool Handled { get; set; }
    }
}
