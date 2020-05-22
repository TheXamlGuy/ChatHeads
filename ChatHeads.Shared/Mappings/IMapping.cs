namespace ChatHeads.Shared.Mappings
{
    public interface IMapping
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TSource, TDestination>(TSource source, string destinationName);

        TDestination Map<TDestination>(object source, string destinationName);
    }
}
