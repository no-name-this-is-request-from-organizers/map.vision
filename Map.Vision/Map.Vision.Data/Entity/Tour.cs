using System;
using System.Collections.Generic;
using System.Text;
using Map.Vision.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Map.Vision.Data.Entity
{
    public class Tour : Base2
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Place> Places { get; set; }

        public Attachment Avatar { get; set; }

        public IList<Attachment> Pictures { get; set; }

        [Column(TypeName = "varchar(24)")]
        public TourType TypeCreator { get; set; }
    }
}
