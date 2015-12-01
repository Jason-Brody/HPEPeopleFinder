using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataLoaderAgent
{
    public class HttpClientHelper
    {
        public static string BaseURL { get; set; }

        public static T GetInfo<T>(string api, Dictionary<string, string> headers = null) where T : class, new()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (headers != null && headers.Count > 0)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                var t = client.GetAsync(api);
                t.Wait();
                HttpResponseMessage response = t.Result;
                if (response.IsSuccessStatusCode)
                {
                    var t1 = response.Content.ReadAsStringAsync();
                    t1.Wait();
                    string result = t1.Result;
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return null;

        }
    }
}
