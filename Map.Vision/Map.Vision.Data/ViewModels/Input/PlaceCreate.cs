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
    public class PlaceCreate
    {
        [Required(ErrorMessage = "Объект должен иметь название!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "У объекта должно быть описание!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "У объекта должно быть краткое описание!")]
        public string SmallDescription { get; set; }

        [Required(ErrorMessage = "У объекта должны быть назначены координаты!")]
        public Coordinates Coordinates { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [Required(ErrorMessage = "У объекта должн быть выбран тип!")]
        public PointType Type { get; set; }

        public string City { get; set; }

        public IFormFile Avatar { get; set; }

        public IFormFileCollection Pictures { get; set; }

        public IFormFile AudioGuide { get; set; }

        public IFormFile AudioHistory { get; set; }
    }
}
