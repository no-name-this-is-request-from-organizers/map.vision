using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Dto;
using Map.Vision.Data.Base;
using Map.Vision.Data.Filters;
using Map.Vision.Data.Entity;

namespace Map.Vision.BI.Interfaces
{
    public interface IPlaces
    {
        Task<PlaceOutputDto> Get(int id);

        Task<IList<Place>> Get(int[] ids);

        Task<IList<PlaceSmallDto>> GetAll(PlaceFilter filter);

        Task<IList<PlaceOutputDto>> GetAllFull(PlaceFilter filter);
    }
}
