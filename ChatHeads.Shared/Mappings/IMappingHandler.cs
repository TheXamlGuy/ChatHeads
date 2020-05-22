namespace ChatHeads.Shared.Mappings
{
    public interface IMappingHandler<in TSource, TDestination>
    {
        TDestination Map(TSource source, TDestination destination);
    }
}
