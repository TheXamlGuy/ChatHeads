using System;

namespace ChatHeads.Shared.LifeCycle
{
    public interface IContainerProvider
    {
        TService Resolve<TService>();

        object Resolve(Type type);

        TService Resolve<TService>(string name);
    }
}
