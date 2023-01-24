using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace carter_cs {

    public class CarterCS
    {
        public string SendMessageToCarter(string apiKey, string message, string uuid, string scene = "level-1")
        {
            var url = "https://api.carterapi.com/v0/chat";
            var payload = JsonConvert.SerializeObject(new { api_key = apiKey, query = message, uuid = uuid, scene });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            string result = "";
            string tid = "";
            using (var client = new HttpClient())
            {
                if (client != null)
                {
                    var response = client.PostAsync(url, content).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;

                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(responseText);

                    result = jsonObject["output"].text.ToString();
                    tid = jsonObject["tid"].ToString();
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
            string tid = "";
            using (var client = new HttpClient())
            {
                if (client != null)
                {
                    var response = client.PostAsync(url, content).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;

                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(responseText);

                    result = jsonObject["output"].text.ToString();
                    tid = jsonObject["tid"].ToString();
                }
            }

            return result;
        }

        

        public void CheckStatus()
        {
            string url = "https://api.carterapi.com/status";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   Console.WriteLine("Carter Servers Are: " + response.StatusCode.ToString());
                }
                else
                {
                    Console.WriteLine("Carter Servers Are: " + response.StatusCode.ToString());
                }
            }
        }

        public void Downvote(string downvotedMessageID)
        {
             
        }
    }
}