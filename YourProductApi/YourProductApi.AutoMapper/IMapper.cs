using System;

namespace YourProductApi.AutoMapper
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource src, TDestination dest);
    }
}
