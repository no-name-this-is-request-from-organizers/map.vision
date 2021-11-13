using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.BI.Interfaces;
using Map.Vision.EF;
using Map.Vision.Data.Base;

namespace Map.Vision.BI.Services
{
    public class Geocoding : IGeocoding
    {
        private readonly IPlaceGeocoding _places;

        public Geocoding(IPlaceGeocoding places)
        {
            _places = places;
        }

        public async Task<int> GetObjectsNearby(Coordinates coordinates)
        {
            var result = await _places.GetPlacesGeocords(coordinates);
            if (result == null || result.Count == 0)
                return 0;

            (int id, double distance) min = (0, 0);
            foreach (var c in result)
            {
                var newDistance = CalculateDistance(coordinates, c.Value);
                if (min.distance == 0 || min.distance > Math.Abs(newDistance))
                {
                    min.id = c.Key;
                    min.distance = newDistance;
                }
            }

            return min.id;
        }

        private double CalculateDistance(Coordinates point1, Coordinates point2)
        {
            var d1 = point1.Lat * (Math.PI / 180.0);
            var num1 = point1.Lng * (Math.PI / 180.0);
            var d2 = point2.Lat * (Math.PI / 180.0);
            var num2 = point2.Lng * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
