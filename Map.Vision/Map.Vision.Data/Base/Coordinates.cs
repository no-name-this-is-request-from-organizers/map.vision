using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Vision.Data.Base
{
    public class Coordinates
    {
        //Приблизительное значение для вычисления расстояния в 100 метров по широте
        public const double _100MetrosForLat = 0.00091;
        
        //Приблизительное значение для вычисления расстояния в 100 метров по долготе
        public const double _100MetrosForLng = 0.00114;

        //Широта 
        public double Lat { get; set; }

        //Долгота
        public double Lng { get; set; }
    }
}
