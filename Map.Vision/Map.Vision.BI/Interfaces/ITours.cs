using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Dto;
using Map.Vision.Data.Filters;

namespace Map.Vision.BI.Interfaces
{
    public interface ITours
    {
        Task<bool> CreateTour(TourInputDto model);

        Task<bool> UpdateTour(TourInputDto model);

        Task<TourOutputDto> Get(int id);

        Task<IList<TourOutputDto>> GetAll(TourFilter filter);
    }
}
