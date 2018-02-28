using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.AutoMapperCore.Mappers
{
    public class MapperCore : IMapperCore
    {
        public TDestination Map<TSource, TDestination>(TSource src)
        {
            return Mapper.Map<TDestination>(src);
        }
    }
}
