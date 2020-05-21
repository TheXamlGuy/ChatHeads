using System.Linq;
using System.Windows;
using ChatHeads.Navigation;
using ChatHeads.Shared.Extensions;
using ChatHeads.Shared.LifeCycle;
using ChatHeads.Shared.Requests;
using ChatHeads.Shared.ViewModels;
using ChatHeads.Views;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatHeads
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            var host = Host.CreateDefaultBuilder(args.Args)
                   .ConfigureServices(ConfigureServices)
                   .Build();

            host.Services.GetService<IChatHeadFlyoutService>().Show("ChatHeadFlyout");
        }

        public void ConfigureServices(IServiceCollection services) => 
            services.AddSingleton<IContainerProvider>(provider =>
            new ContainerProvider(provider.GetService,
                name => provider.GetServices<IServiceByNameFactory>().FirstOrDefault(x => x.Name == name)
                ?.GetService())).AddMediatR(typeof(QueryChatHeadNotificationHandler))
            .AddTransient<IChatHeadFlyoutService, ChatHeadFlyoutService>()
            .AddViewWithViewModel<ChatHeadFlyout, ChatHeadListViewModel>();
    }
}
