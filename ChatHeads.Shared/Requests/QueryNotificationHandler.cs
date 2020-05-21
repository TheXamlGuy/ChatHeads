using ChatHeads.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChatHeads.Shared.Requests
{
    public class QueryNotificationHandler : IRequestHandler<QueryNotificationRequest, string>
    {
        public async Task<string> Handle(QueryNotificationRequest request, CancellationToken cancellationToken)
        {

            using var dbContext = new NotificationsContext();
            var notification = await dbContext.Notification.FirstOrDefaultAsync(x => x.Id == args.UserNotificationId);
            if (notification == null) return;
        }
    }
}
