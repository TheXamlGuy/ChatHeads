namespace ChatHeads.Shared.LifeCycle
{
    public interface IServiceByNameFactory
    {
        string Name { get; }

        object GetService();

        TService GetService<TService>();
    }
}
