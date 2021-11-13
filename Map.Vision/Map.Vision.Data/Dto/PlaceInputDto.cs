using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Enums;

namespace Map.Vision.Data.Dto
{
    public class PlaceInputDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public PointType Type { get; set; }

        public Coordinates Coordinates { get; set; }

        public string City { get; set; }

        public Attachment Avatar { get; set; }

        public IList<Attachment> Pictures { get; set; }

        public Attachment AudioGuide { get; set; }

        public Attachment AudioHistory { get; set; }
    }
}
