using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Enums;

namespace Map.Vision.Data.Dto
{
    public class SensorOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public PointType Type { get; set; }

        public Coordinates Coordinates { get; set; }

        public string City { get; set; }

        public string Avatar { get; set; }

        public IList<string> Pictures { get; set; }

        public string AudioGuide { get; set; }

        public string AudioHistory { get; set; }
    }
}
