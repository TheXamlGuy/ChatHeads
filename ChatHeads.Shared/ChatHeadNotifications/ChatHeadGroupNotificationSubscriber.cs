using System.Collections.Generic;

namespace ChatHeads.Shared.ChatHeadNotifications
{
    public class ChatHeadGroupNotificationSubscriber : IChatHeadNotificationSubscriber
    {
        private readonly IList<IChatHeadNotificationHandler> _groupNotifications;
        public ChatHeadGroupNotificationSubscriber(IList<IChatHeadNotificationHandler> groupNotifications)
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
