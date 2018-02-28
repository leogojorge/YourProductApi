using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.AutoMapperCore
{
    public interface IMapperCore
    {
        TDestination Map<TSource, TDestination>(TSource src);
    }
}
