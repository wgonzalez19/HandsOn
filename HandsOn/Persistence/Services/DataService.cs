using HandsOn.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOn.Persistence.Services
{
    public class DataService<TEntity> where TEntity : class
    {
        public static async Task<IEnumerable<TEntity>> GetData(string uri)
        {
            ApiHelper.InitializeClient();
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                    throw new NullReferenceException($"{typeof(TEntity).FullName} is empty");

                var jsonString = await response.Content.ReadAsStringAsync();

                IEnumerable<TEntity> result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(jsonString);

                return result;
            }
        }
    }
}
