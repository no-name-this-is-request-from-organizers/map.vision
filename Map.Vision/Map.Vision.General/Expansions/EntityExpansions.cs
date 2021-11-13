using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Entity;

namespace Map.Vision.General.Expansions
{
    public static class EntityExpansions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> entity, FilterEntity<T> filter)
            where T : Base
        {
            entity = entity.Where(filter.Build());
            if (filter.Skip > 0)
                entity = entity.Skip(filter.Skip);
            if (filter.Take > 0)
                entity = entity.Take(filter.Take);
            else
                entity = entity.Take(500);

            return entity.OrderByDescending(x => x.Id);
        }
    }
}
