using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Map.Vision.Data.Entity;

namespace Map.Vision.Data.Base
{
    public class Filter
    {
        public int Take { get; set; }

        public int Skip { get; set; }
    }

    public class FilterEntity<T> : Filter
        where T : Entity.Base
    {
        public virtual Expression<Func<T, bool>> Build() => x => true;
    }
}
