using ChatHeads.Shared.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.Notifications
{
    public class NotificationListener : INotificationListener
    {
        private readonly UserNotificationListener _listener;
        private readonly IMediator _mediator;
        private readonly IList<INotificationHandler> _notificationHandlers;

        public NotificationListener(IMediator mediator, IList<INotificationHandler> notificationHandlers)
        {
            _mediator = mediator;
            _notificationHandlers = notificationHandlers;

            _listener = UserNotificationListener.Current;
        }

        ~NotificationListener()
        {
            _listener.NotificationChanged -= OnNotificationChanged;
        }

        public void Start() => _listener.NotificationChanged += OnNotificationChanged;

        public void Stop() => _listener.NotificationChanged -= OnNotificationChanged;

        private async void OnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
        {
            if (args.ChangeKind == UserNotificationChangedKind.Added)
            {
                var notification = await _mediator.Send(new QueryNotificationRequest { Id = args.UserNotificationId });
                if (notification != null)
                {
                    var eventArgs = new NotificationEventArgs { Notification = notification };
                    foreach (var notificationHandler in _notificationHandlers.ToList())
                    {
                        if (eventArgs.Handled) break;
                        notificationHandler.OnHandleChatHeadNotification(eventArgs);
                    }
                }
            }
        }
    }
}