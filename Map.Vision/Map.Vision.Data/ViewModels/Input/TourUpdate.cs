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
    public class TourUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [MinLength(2, ErrorMessage = "Маршрут должен содержать минимум две точки!")]
        public int[] SensorsIds { get; set; }

        public IFormFile Avatar { get; set; }

        public IFormFileCollection Pictures { get; set; }
    }
}
