using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PeopleFinder
{
    internal class HttpHelper
    {
        public static string BaseURL = "http://peoplefinder-api.corp.hpecorp.net/v1.0/person/";

        //api references
        //api:detail/yang.zhou4@hpe.com returnType:SingleInfo
        //api:mgr/yang.zhou4@hpe.com returnType:MgrInfo
        //api:search?search=ASIAPACIFIC:yanzhou&type=ntlogin returnType:SearchInfo
        //api:search?type=email&search=miguel.quintero@hp.com returnType:SearchInfo

        public static async Task<T> GetInfo<T>(string api,Dictionary<string,string> headers = null) where T : class, new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if(headers!=null && headers.Count > 0)
                {
                    foreach(var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return null;

        }
    }
}
