using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Dto;
using Map.Vision.Data.Base;

namespace Map.Vision.BI.Interfaces
{
    public interface IAdmin
    {
        Task<bool> CreateSensor(SensorInputDto sensor);

        Task<bool> UpdateSensor(SensorInputDto sensor);

        Task<bool> RemoveSensor(int id);
    }
}
