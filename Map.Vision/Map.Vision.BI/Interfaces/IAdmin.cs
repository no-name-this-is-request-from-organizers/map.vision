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
        Task<bool> CreatePlace(PlaceInputDto place);

        Task<bool> UpdatePlace(PlaceInputDto place);

        Task<bool> RemovePlace(int id);
    }
}
