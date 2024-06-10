using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGintec.Service
{
    public partial class HttpClientService
    {
        public HttpClient GetPlatfromSpecificHttpClient()
        {
            var httpMessageHandler = GetPlatfromSpecificHttpMessageHandler();
            return new HttpClient(httpMessageHandler);
        }
        public partial HttpMessageHandler GetPlatfromSpecificHttpMessageHandler();
    }
}
