using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGintec.Models
{
    public class HttpResponse<T>
    {
        public int StatusCode { get; set; }
        public string StatusString { get; set; }
        public T Data { get; set; }
    }
}
