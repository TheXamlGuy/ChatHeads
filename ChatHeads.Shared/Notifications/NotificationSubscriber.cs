using System.Collections.Generic;

namespace ChatHeads.Shared.Notifications
{
    public class NotificationSubscriber : INotificationSubscriber
    {
        private readonly IList<INotificationHandler> _groupNotifications;
        public NotificationSubscriber(IList<INotificationHandler> groupNotifications)
        {
            _groupNotifications = groupNotifications;
        }

        public void Subscribe(INotificationHandler groupNotification)
        {
            if (!_groupNotifications.Contains(groupNotification))
                _groupNotifications.Insert(0, groupNotification);
        }
    }
}
