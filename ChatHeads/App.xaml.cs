using System.Windows;
using ChatHeads.Navigation;
using ChatHeads.Shared.Extensions;
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

            Host.CreateDefaultBuilder(args.Args)
                   .ConfigureServices(ConfigureServices)
                   .Build();      
        }

        public void ConfigureServices(IServiceCollection services) => 
            services.AddMediatR(typeof(QueryNotificationHandler))
            .AddTransient<IChatHeadFlyoutService, ChatHeadFlyoutService>()
            .AddViewWithViewModel<ChatHeadFlyout, ChatHeadListViewModel>();
    }
}
