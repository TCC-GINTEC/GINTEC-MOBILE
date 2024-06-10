
namespace AppGintec.Service
{
    public partial class HttpClientService
    {
        public partial HttpMessageHandler GetPlatfromSpecificHttpMessageHandler()
        {
            var handler = new NSUrlSessionHandler
            {
                TrustOverrideForUrl= (nsUrlSessionHandlerSene)
            };
            
            return handler;
        }
    }
}
