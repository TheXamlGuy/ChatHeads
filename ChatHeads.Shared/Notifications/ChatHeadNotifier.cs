using ChatHeads.Shared.Requests;
using MediatR;
using System.Collections.Generic;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.Notifications
{
    public class ChatHeadNotifier : IChatHeadNotifier
    {
        private readonly UserNotificationListener _listener;
        private readonly IMediator _mediator;
        private IList<IChatHeadNotification> _notifications;

        public ChatHeadNotifier(IMediator mediator)
        {
            _mediator = mediator;
            _notifications = new List<IChatHeadNotification>();

            _listener = UserNotificationListener.Current;
            _listener.NotificationChanged += OnNotificationChanged;
        }

        ~ChatHeadNotifier()
        {
            _listener.NotificationChanged -= OnNotificationChanged;
        }

        public void Subscribe(IChatHeadNotification notification)
        {
            if (!_notifications.Contains(notification))
                _notifications.Add(notification);
        }

        private async void OnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
        {
            if (args.ChangeKind == UserNotificationChangedKind.Added)
            {
                var notification = await _mediator.Send(new QueryNotificationRequest { Id = args.UserNotificationId });
                if (notification != null)
                {

                }
            }
        }
    }
}