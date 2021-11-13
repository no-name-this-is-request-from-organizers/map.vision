using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Entity;
using System.Linq.Expressions;

namespace Map.Vision.Data.Filters
{
    public class TourFilter : FilterEntity<Tour>
    {
        public int IncludePlaceId { get; set; }

        public override Expression<Func<Tour, bool>> Build() => IncludePlaceId > 0 ? x => x.Places.Any(y => y.Id == IncludePlaceId) : base.Build();
    }
}
