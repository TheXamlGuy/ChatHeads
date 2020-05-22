using System.Collections.Generic;

namespace ChatHeads.Shared.Notifications
{
    public class ChatHeadNotificationSubscriber : IChatHeadNotificationSubscriber
    {
        private readonly IList<IChatHeadNotificationHandler> _groupNotifications;
        public ChatHeadNotificationSubscriber(IList<IChatHeadNotificationHandler> groupNotifications)
        {
            _groupNotifications = groupNotifications;
        }

        public void Subscribe(IChatHeadNotificationHandler groupNotification)
        {
            if (!_groupNotifications.Contains(groupNotification))
                _groupNotifications.Insert(0, groupNotification);
        }
    }
}
