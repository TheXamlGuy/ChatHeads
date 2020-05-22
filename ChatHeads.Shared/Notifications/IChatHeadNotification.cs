namespace ChatHeads.Shared.Notifications
{
    public interface IChatHeadNotification
    {
        uint Id { get; set; }

        uint GroupId { get; }

        void OnNotificationChanged();
    }
}
