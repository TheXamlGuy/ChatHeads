using ChatHeads.Shared.LifeCycle;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ChatHeads.Shared.Extensions
{
    public static class ContainerExtension
    {
        public static IServiceCollection AddMapping<TView>(this IServiceCollection services, string name = "") where TView : DependencyObject
        {
            name = !string.IsNullOrEmpty(name) ? name : typeof(TView).Name;

            services.AddTransient(typeof(TView));
            services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TView), typeof(TView), name));

            return services;
        }

        public static IServiceCollection AddView<TView>(this IServiceCollection services, string name = "") where TView : DependencyObject
        {
            name = !string.IsNullOrEmpty(name) ? name : typeof(TView).Name;

            services.AddTransient(typeof(TView));
            services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TView), typeof(TView), name));

            return services;
        }

        public static IServiceCollection AddViewWithViewModel<TView, TViewModel>(this IServiceCollection services, string name = "", Type viewModelServiceType = null, ServiceLifetime lifetime = ServiceLifetime.Transient) where TView : DependencyObject where TViewModel : class
        {
            name = !string.IsNullOrEmpty(name) ? name : typeof(TView).Name;

            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient(typeof(TView));
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(typeof(TView));
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(typeof(TView));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
            }

            if (viewModelServiceType == null)
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Transient:
                        services.AddTransient(typeof(TViewModel));
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(typeof(TViewModel));
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(typeof(TViewModel));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
                }
            }
            else
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Transient:
                        services.AddTransient(viewModelServiceType, typeof(TViewModel));
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(viewModelServiceType, typeof(TViewModel));
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(viewModelServiceType, typeof(TViewModel));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
                }
            }

            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TView), typeof(TView), name));
                    services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TViewModel), typeof(TViewModel), $"{name}ViewModel"));
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TView), typeof(TView), name));
                    services.AddSingleton<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TViewModel), typeof(TViewModel), $"{name}ViewModel"));
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TView), typeof(TView), name));
                    services.AddScoped<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TViewModel), typeof(TViewModel), $"{name}ViewModel"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
            }

            return services;
        }
    }
}
