using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Map.Vision.Data.Entity
{
    public class Sensor : Base
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "varchar(24)")]
        public PointType Type { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}
