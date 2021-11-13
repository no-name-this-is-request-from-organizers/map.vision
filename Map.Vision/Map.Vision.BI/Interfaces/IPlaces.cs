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
    public interface ISensors
    {
        Task<SensorOutputDto> Get(int id);

        Task<IList<Sensor>> Get(int[] ids);

        Task<IList<SensorSmallDto>> GetAll(SensorFilter filter);

        Task<IList<SensorOutputDto>> GetAllFull(SensorFilter filter);
    }
}
