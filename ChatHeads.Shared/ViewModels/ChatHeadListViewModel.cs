using ChatHeads.Data;
using ChatHeads.Shared.Models;
using ChatHeads.Shared.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml.Serialization;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace ChatHeads.Shared.ViewModels
{
    public class ChatHeadListViewModel : ListViewModel<ChatHeadItemViewModel>
    {
        private readonly IMediator _mediator;

        public ChatHeadListViewModel(IMediator mediator)
        {
            var listener = UserNotificationListener.Current;
            listener.NotificationChanged += ListenerOnNotificationChanged;

            _mediator = mediator;
        }

        private async void ListenerOnNotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
        {
            if (args.ChangeKind == UserNotificationChangedKind.Added)
            {
                var notification = await _mediator.Send(new QueryChatHeadNotificationRequest { Id = args.UserNotificationId });
                
                if (notification != null)
                {
                    var vm = new ChatHeadItemViewModel
                    {
                        ImageSource = notification.ImageSource
                    };

                    Add(vm);
                }
         
            }
        }
    }
}