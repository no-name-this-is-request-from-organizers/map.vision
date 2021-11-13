using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Map.Vision.Data.Entity
{
    public class Place : Base
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        [Column(TypeName = "varchar(24)")]
        public PointType Type { get; set; }

        public Coordinates Coordinates { get; set; }

        public string City { get; set; }

        public Attachment Avatar { get; set; }

        public IList<Attachment> Pictures { get; set; }

        public Attachment AudioGuide { get; set; }

        public Attachment AudioHistory { get; set; }
    }
}
