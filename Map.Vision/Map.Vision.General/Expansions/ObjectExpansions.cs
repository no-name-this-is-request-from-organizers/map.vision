using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Map.Vision.General.Expansions
{
    public static class ObjectExpansions
    {
        public static string ToJson(this object data) =>
            JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

        public static IList<T> ToListOrNull<T>(this IEnumerable<T> data) => data is null ? null : data.ToList();
    }
}
