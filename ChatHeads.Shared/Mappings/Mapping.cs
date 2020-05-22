using ChatHeads.Shared.LifeCycle;
using System;

namespace ChatHeads.Shared.Mappings
{
    public class Mapping : IMapping
    {
        private readonly IContainerProvider _containerProvider;

        public Mapping(IContainerProvider containerProvider) => _containerProvider = containerProvider;

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var destination = _containerProvider.Resolve<TDestination>();
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            dynamic handler = _containerProvider.Resolve(typeof(IMappingHandler<TSource, TDestination>));
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Map(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            dynamic handler = _containerProvider.Resolve(typeof(IMappingHandler<,>).MakeGenericType(source.GetType(), destination.GetType()));
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Map((dynamic)source, (dynamic)destination);
        }

        public TDestination Map<TDestination>(object source, string destinationName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var destination = _containerProvider.Resolve<TDestination>(destinationName);
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            dynamic handler = _containerProvider.Resolve(typeof(IMappingHandler<,>).MakeGenericType(source.GetType(), destination.GetType()));
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Map((dynamic)source, (dynamic)destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, string destinationName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var destination = _containerProvider.Resolve<TDestination>(destinationName);
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            dynamic handler = _containerProvider.Resolve(typeof(IMappingHandler<TSource, TDestination>));
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Map(source, destination);
        }
    }
}
