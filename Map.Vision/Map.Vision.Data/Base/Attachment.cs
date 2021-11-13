using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Map.Vision.Data.Base
{
    public class Attachment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Stream Stream { get; set; }
    }
}
