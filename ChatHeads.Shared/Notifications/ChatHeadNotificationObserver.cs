using ChatHeads.Shared.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.Notifications
{

    public class ChatHeadNotificationObserver : INotificationObserver
    {    
        private readonly IMediator _mediator;

        private IList<ChatHeadNotification> _chatHeadNotifications = new List<ChatHeadNotification>();

        public ChatHeadNotificationObserver(IMediator mediator)
        {
            var listener = UserNotificationListener.Current;
            listener.NotificationChanged += ListenerOnNotificationChanged;

            _mediator = mediator;
        }

        public void Remove(int id)
        {

        }

        public void Clear() => _chatHeadNotifications.Clear();


        private async void ListenerOnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
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
