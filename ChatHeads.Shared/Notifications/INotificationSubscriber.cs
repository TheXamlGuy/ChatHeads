namespace ChatHeads.Shared.Notifications
{
    public interface INotificationSubscriber
    {
        void Subscribe(INotificationHandler notification);
    }
}
