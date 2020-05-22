namespace ChatHeads.Shared.Notifications
{
    public interface INotificationHandler
    {
        void OnHandleChatHeadNotification(NotificationEventArgs args);
    }
}
