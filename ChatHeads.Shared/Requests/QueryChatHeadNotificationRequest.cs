using ChatHeads.Shared.Models;
using MediatR;

namespace ChatHeads.Shared.Requests
{
    public class QueryChatHeadNotificationRequest : IRequest<ChatHeadNotification>
    { 
        public uint Id { get; set; }
    }
}
