using ChatHeads.Shared.LifeCycle;
using ChatHeads.UI.Controls;
using System;

namespace ChatHeads.Navigation
{
    public class ChatHeadFlyoutService : IChatHeadFlyoutService
    {
        private readonly IContainerProvider _provider;

        public ChatHeadFlyoutService(IContainerProvider provider) => _provider = provider;

        public void Show(string name)
        {
            var flyout = ResolveFromName(name);
            BindViewModel(name, flyout);

            flyout.Show();
        }

        private ChatHeadFlyout ResolveFromName(string name)
        {
            var flyout = _provider.Resolve<ChatHeadFlyout>(name);
            if (flyout == null) throw new NullReferenceException(nameof(flyout));
            return flyout;
        }

        private void BindViewModel(string name, ChatHeadFlyout flyout)
        {
            var viewModel = _provider.Resolve<object>($"{name}ViewModel");
            if (viewModel == null) return;

            flyout.DataContext = viewModel;
        }
    }
}
