using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;

namespace Map.Vision.BI.Interfaces
{
    public interface IGeocoding
    {
        Task<int> GetObjectsNearby(Coordinates coordinates);
    }
}
