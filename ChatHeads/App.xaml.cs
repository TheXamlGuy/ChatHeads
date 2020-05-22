using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using ChatHeads.Navigation;
using ChatHeads.Shared.Extensions;
using ChatHeads.Shared.LifeCycle;
using ChatHeads.Shared.Mappings;
using ChatHeads.Shared.Notifications;
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

            var host = Host.CreateDefaultBuilder()
                   .ConfigureServices(ConfigureServices)
                   .Build();

            host.Services.GetService<IChatHeadFlyoutService>().Show("ChatHeadFlyout");
            host.Services.GetService<INotificationListener>().Start();
        }

        public void ConfigureServices(IServiceCollection services) =>
            services.AddSingleton<IContainerProvider>(provider =>
            new ContainerProvider(provider.GetService,
                name => provider.GetServices<IServiceByNameFactory>().FirstOrDefault(x => x.Name == name)
                ?.GetService()))
            .AddMediatR(typeof(QueryNotificationHandler))
            .AddSingleton<IMapping, Mapping>()
            .AddTransient<IChatHeadFlyoutService, ChatHeadFlyoutService>()
            .AddSingleton<INotificationListener, NotificationListener>()
            .AddSingleton<IList<INotificationHandler>, List<INotificationHandler>>()
            .AddSingleton<INotificationSubscriber, NotificationSubscriber>()
            .AddTransient<IChatHeadFlyoutService, ChatHeadFlyoutService>()
            .AddTransientMany(typeof(IMappingHandler<,>), new[] { Assembly.GetAssembly(typeof(IMappingHandler<,>)) })
            .AddTransient<ChatHeadItemViewModel>()
            .AddViewWithViewModel<ChatHeadFlyout, ChatHeadListViewModel>();
    }
}
