using ChatHeads.Shared.Models;
using MediatR;

namespace ChatHeads.Shared.Requests
{
    public class QueryNotificationRequest : IRequest<Notification>
    { 
        public uint Id { get; set; }
    }
}
