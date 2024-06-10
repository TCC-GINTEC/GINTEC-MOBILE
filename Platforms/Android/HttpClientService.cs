using Javax.Net.Ssl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android.Net;
using Object = Java.Lang.Object;

namespace AppGintec.Service
{
    public partial class HttpClientService
    {
        public partial HttpMessageHandler GetPlatfromSpecificHttpMessageHandler()
        {
            var androidHttpHandler = new AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                {
                    if (certificate?.Issuer == "CN=R3, O=Let's Encrypt, C=US" || sslPolicyErrors == SslPolicyErrors.None)
                        return true;
                    return false;
                }
            };
            return androidHttpHandler;
        }
        class UrlHostAndroidMessageHandler : AndroidMessageHandler
        {
            protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection) => new UrlHostNameVerifier();            
        }
        class UrlHostNameVerifier : Object, IHostnameVerifier
        {
            public bool Verify(string? hostname, ISSLSession? session)
            {
                if (HttpsURLConnection.DefaultHostnameVerifier.Verify(hostname, session) || hostname == "api.faisca-online")
                    return true;
                return false;
            }
        }
    }
}
