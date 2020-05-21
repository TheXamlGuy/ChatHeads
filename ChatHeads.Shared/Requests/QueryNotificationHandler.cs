using ChatHeads.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Notification = ChatHeads.Shared.Models.Notification;

namespace ChatHeads.Shared.Requests
{
    public class QueryNotificationHandler : IRequestHandler<QueryNotificationRequest, Notification>
    {
        public async Task<Notification> Handle(QueryNotificationRequest request, CancellationToken cancellationToken)
        {
            using var dbContext = new NotificationsContext();
            var notification = await dbContext.Notification.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (notification == null) return null;

            var xml = XDocument.Parse(notification.Payload);
            var image = xml.XPathSelectElement($".//image");

            return new Notification();
        }
    }
}
