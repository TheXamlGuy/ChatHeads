namespace ChatHeads.Shared.Notifications
{
    public interface IChatHeadNotificationSubscriber
    {
        void Subscribe(IChatHeadNotificationHandler notification);
    }
}
