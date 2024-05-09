using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class MappingExtension
    {
        public static IEnumerable<TDestination> MapList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            // Map each item in the source list to the destination list
            return source.Select(x => Map<TSource, TDestination>(x));
        }

        public static TDestination Map<TSource, TDestination>(this TSource source)
        {
            // Create a mapping configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                // Create a mapping from the source to the destination
                cfg.CreateMap<TSource, TDestination>();
            });

            // Create a mapper
            var mapper = config.CreateMapper();

            // Return the Mapped source to the destination
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
