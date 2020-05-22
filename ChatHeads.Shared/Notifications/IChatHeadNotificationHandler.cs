namespace ChatHeads.Shared.Notifications
{
    public interface IChatHeadNotificationHandler
    {
        void OnHandleChatHeadNotification(ChatHeadNotificationEventArgs args);
    }
}
