using ChatHeads.Shared.LifeCycle;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChatHeads.Shared.Extensions
{
    public static class ContainerExtension
    {
        public static IServiceCollection AddTransientMany<TService>(this IServiceCollection services, IEnumerable<Assembly> assemblies) => AddTransientMany(services, typeof(TService), assemblies);

        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, string name = "")
        {
            services.AddSingleton(typeof(TService), typeof(TImplementation));
            services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TService), typeof(TImplementation), name));

            return services;
        }

        public static IServiceCollection AddTransient<TService>(this IServiceCollection services, string name = "")
        {
            services.AddTransient(typeof(TService));
            services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, typeof(TService), typeof(TService), name));

            return services;
        }

        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType, string name)
        {
            services.AddTransient(serviceType, implementationType);
            services.AddTransient<IServiceByNameFactory>(provider => new ServiceByNameFactory(provider, serviceType, implementationType, name));

            return services;
        }

        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, string name) => AddTransient(services, typeof(TService), typeof(TImplementation), name);

        public static IServiceCollection AddTransientMany(this IServiceCollection services, System.Type serviceType, IEnumerable<Assembly> assemblies, string name = "")
        {
            foreach (var (x, z) in assemblies.Distinct().SelectMany(a => a.GetTypes()).SelectMany(x => x.GetInterfaces().Select(z => (x, z))))
            {
                if ((!serviceType.IsAssignableFrom(x) || x.IsInterface || x.IsAbstract) &&
                    (x.BaseType?.IsGenericType != true ||
                     !serviceType.IsAssignableFrom(x.BaseType.GetGenericTypeDefinition())) &&
                    (!z.IsGenericType || !serviceType.IsAssignableFrom(z.GetGenericTypeDefinition()))) continue;
                if (!string.IsNullOrEmpty(name))
                {
                    services.AddTransient(z, x, name);

                }
                else
                {
                    services.AddTransient(z, x);
                }
            }

            return services;
        }
    }
}
