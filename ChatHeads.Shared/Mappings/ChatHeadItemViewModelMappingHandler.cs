using ChatHeads.Shared.ViewModels;
using System.Collections.Generic;

namespace ChatHeads.Shared.Mappings
{
    public class ChatHeadItemViewModelMappingHandler : IMappingHandler<Dictionary<string, string>, ChatHeadItemViewModel>
    {
        public ChatHeadItemViewModel Map(Dictionary<string, string> source, ChatHeadItemViewModel destination)
        {
            return destination;
        }
    }
}
