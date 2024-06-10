using AppGintec.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppGintec.Service
{
    public class ApiService<T>
    {
        public static string _accessToken;
        //private string UrlBase = "https://localhost:44397/";
        private string UrlBase = "https://api-faisca.online/Gintec/";
        //private X509Certificate certificate = new X509Certificate(AppContext.BaseDirectory + "/Gintec/cert/api_faiscaonline_key.pem");       
        private HttpClient GetHttp()
        {
            return new HttpClientService().GetPlatfromSpecificHttpClient();
        }
        public async Task<HttpResponse<T>> GetAsync(string url)
        {
            var httpClient = GetHttp();
            httpClient.BaseAddress = new Uri(UrlBase + url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            T responseData = JsonConvert.DeserializeObject<T>(responseBody);

            return new HttpResponse<T>
            {
                StatusCode = (int)response.StatusCode,
                StatusString = response.StatusCode.ToString(),
                Data = responseData
            };
        }

        public HttpResponse<T> PostAsync(string url, object data)
        {
            var httpClient = GetHttp();
            httpClient.BaseAddress = new Uri(UrlBase + url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var jsonContent = JsonConvert.SerializeObject(data);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync(url, contentString).Result;

            T responseData = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

            return new HttpResponse<T>
            {
                StatusCode = (int)response.StatusCode,
                StatusString = response.StatusCode.ToString(),
                Data = responseData
            };
        }
    }
}

