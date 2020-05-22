using ChatHeads.Shared.Requests;
using MediatR;
using System.Collections.Generic;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.Notifications
{
    public class ChatHeadNotification : IChatHeadNotification
    {
        private readonly UserNotificationListener _listener;
        private readonly IMediator _mediator;
        private readonly IList<IChatHeadNotificationHandler> _notificationHandlers;

        public ChatHeadNotification(IMediator mediator, IList<IChatHeadNotificationHandler> notificationHandlers)
        {
            _mediator = mediator;
            _notificationHandlers = notificationHandlers;

            _listener = UserNotificationListener.Current;
            _listener.NotificationChanged += OnNotificationChanged;
        }

        ~ChatHeadNotification()
        {
            _listener.NotificationChanged -= OnNotificationChanged;
        }

        private async void OnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
        {
            if (args.ChangeKind == UserNotificationChangedKind.Added)
            {
                var notification = await _mediator.Send(new QueryNotificationRequest { Id = args.UserNotificationId });
                if (notification != null)
                {
                    var eventArgs = new ChatHeadNotificationEventArgs { Notification = notification };
                    foreach (var notificationHandler in _notificationHandlers)
                    {
                        if (eventArgs.Handled) break;
                        notificationHandler.OnHandleChatHeadNotification(eventArgs);
                    }
                }
            }
        }
    }
}