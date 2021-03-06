using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Map.Vision.Data.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Map.Vision.Data.ViewModels.Input
{
    public class SensorUpdate
    {
        [Required(ErrorMessage = "ID должен быть обязателен для редактироания!")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Coordinates Coordinates { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PointType Type { get; set; }
    }
}
