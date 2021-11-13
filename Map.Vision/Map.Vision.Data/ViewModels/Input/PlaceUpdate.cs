using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Map.Vision.Data.ViewModels.Input
{
    public class PlaceUpdate
    {
        [Required(ErrorMessage = "ID должен быть обязателен для редактироания!")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public Coordinates Coordinates { get; set; }

        public IFormFile Avatar { get; set; }

        public IFormFileCollection Pictures { get; set; }

        public IFormFile AudioGuide { get; set; }

        public IFormFile AudioHistory { get; set; }
    }
}
