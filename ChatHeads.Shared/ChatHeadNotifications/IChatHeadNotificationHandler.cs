namespace ChatHeads.Shared.ChatHeadNotifications
{
    public interface IChatHeadNotificationHandler
    {
        void OnHandleChatHeadNotification(ChatHeadNotificationEventArgs args);
    }
}
