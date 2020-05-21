using System;

namespace ChatHeads.Shared.LifeCycle
{
    public class ContainerProvider : IContainerProvider
    {
        private readonly Func<Type, object> _typeFactory;
        private readonly Func<string, object> _namedFactory;

        public ContainerProvider(Func<Type, object> typeFactory, Func<string, object> namedFactory)
        {
            _typeFactory = typeFactory;
            _namedFactory = namedFactory;
        }

        public TService Resolve<TService>() => (TService)_typeFactory(typeof(TService));

        public object Resolve(Type type) => _typeFactory(type);

        public TService Resolve<TService>(string name) => (TService)_namedFactory(name);
    }
}
