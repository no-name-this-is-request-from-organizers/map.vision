using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Map.Vision.BI.Interfaces
{
    public interface IDataSend
    {
        Task<string> PostFileWithStringContent((Stream Stream, string Name) file, string url, string token = null);

        Task Post(object data, string url, string token = null);

        Task<T> Post<T>(object data, string url, string token = null);
    }
}
