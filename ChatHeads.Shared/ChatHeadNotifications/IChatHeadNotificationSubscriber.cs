namespace ChatHeads.Shared.ChatHeadNotifications
{
    public interface IChatHeadNotificationSubscriber
    {
        void Subscribe(IChatHeadNotificationHandler notification);
    }
}
