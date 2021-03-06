﻿using ChatHeads.Shared.Models;
using ChatHeads.Shared.ViewModels;

namespace ChatHeads.Shared.Mappings
{
    public class ChatHeadItemViewModelMappingHandler : IMappingHandler<Notification, ChatHeadItemViewModel>
    {
        public ChatHeadItemViewModel Map(Notification source, ChatHeadItemViewModel destination)
        {
            destination.Id = source.Id; 
            destination.Group = source.Group;
            destination.ImageSource = source.ImageSource;
            destination.NotificationBadgeCount = 1;

            return destination;
        }
    }
}
