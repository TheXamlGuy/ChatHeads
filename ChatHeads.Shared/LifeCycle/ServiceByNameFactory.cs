using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ChatHeads.Shared.LifeCycle
{
    public class ServiceByNameFactory : IServiceByNameFactory
    {
        private readonly IServiceProvider _provider;
        private readonly Type _implementationType;
        private readonly Type _serviceType;

        public ServiceByNameFactory(IServiceProvider provider, Type serviceType, Type implementationType, string name)
        {
            _provider = provider;
            _serviceType = serviceType;
            _implementationType = implementationType;

            Name = name;
        }

        public object GetService() => _provider.GetServices(_serviceType).FirstOrDefault(x => x.GetType() == _implementationType);

        public TService GetService<TService>() => (TService)_provider.GetServices(_serviceType).FirstOrDefault(x => x.GetType() == _implementationType);

        public string Name { get; }
    }
}
