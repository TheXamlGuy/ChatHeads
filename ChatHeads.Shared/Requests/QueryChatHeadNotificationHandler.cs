using ChatHeads.Data;
using ChatHeads.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ChatHeads.Shared.Requests
{
    public class QueryChatHeadNotificationHandler : IRequestHandler<QueryChatHeadNotificationRequest, ChatHeadNotification>
    {
        public async Task<ChatHeadNotification> Handle(QueryChatHeadNotificationRequest request, CancellationToken cancellationToken)
        {
            using var dbContext = new NotificationsContext();
            var notification = await dbContext.Notification.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (notification == null) return null;

            var xml = XDocument.Parse(notification.Payload);
            XElement imageElement = xml.XPathSelectElement($".//image");

            var imageSource = (string)imageElement?.Attribute("src");

            return new ChatHeadNotification
            {
                ImageSource = imageSource
            };
        }
    }
}
