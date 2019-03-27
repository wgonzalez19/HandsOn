using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HandsOn.Helpers
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            string uri = "http://masglobaltestapi.azurewebsites.net/";

            ApiClient = new HttpClient()
            {
                BaseAddress = new Uri(uri)
            };
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
