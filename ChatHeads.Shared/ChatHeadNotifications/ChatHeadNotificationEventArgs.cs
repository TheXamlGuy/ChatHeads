namespace ChatHeads.Shared.ChatHeadNotifications
{
    public class ChatHeadNotificationEventArgs
    {
        public uint Id { get; internal set; }
        public uint GroupId { get; internal set; }
        public string Text { get; internal set; }
        public bool Handled { get; set; }
    }
}
