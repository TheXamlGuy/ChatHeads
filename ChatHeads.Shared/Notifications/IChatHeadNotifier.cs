namespace ChatHeads.Shared.Notifications
{
    public interface IChatHeadNotifier
    {
        void Subscribe(IChatHeadNotification observer);
    }
}