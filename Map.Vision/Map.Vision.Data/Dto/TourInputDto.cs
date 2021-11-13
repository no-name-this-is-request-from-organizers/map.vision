using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Enums;

namespace Map.Vision.Data.Dto
{
    public class TourInputDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PointType Type { get; set; }

        public int[] PlacesIds { get; set; }

        public Attachment Avatar { get; set; }

        public List<Attachment> Pictures { get; set; }
    }
}
