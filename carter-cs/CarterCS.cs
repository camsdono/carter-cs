using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace carter_cs {
    public class CarterCS
    {
        public string SendMessageToCarter(string apiKey, string message, string uuid, string scene = "level-1")
        {
            var url = "https://api.carterapi.com/v0/chat";
            var payload = JsonConvert.SerializeObject(new { api_key = apiKey, query = message, uuid = uuid, scene });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            string result = "";
            using (var client = new HttpClient())
            {
                if (client != null)
                {
                    var response = client.PostAsync(url, content).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;

                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(responseText);

                    result = jsonObject["output"].text.ToString();
                }
            }
            return result;
        }

        public string SendMessageToCarter(string apiKey, string message, string uuid)
        {
            var url = "https://api.carterapi.com/v0/chat";
            var payload = JsonConvert.SerializeObject(new { api_key = apiKey, query = message, uuid = uuid });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            string result = "";
            using (var client = new HttpClient())
            {
                if (client != null)
                {
                    var response = client.PostAsync(url, content).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;

                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(responseText);

                    result = jsonObject["output"].text.ToString();
                }
            }

            return result;
        }
    }
}