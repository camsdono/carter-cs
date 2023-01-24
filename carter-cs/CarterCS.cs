using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace carter_cs
{
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


        private string SendMessageInConversaition(string apiKey, string message, string uuid)
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

                    var jsonObject = System.Text.Json.JsonSerializer.Deserialize<dynamic>(responseText);
                    result = System.Text.Json.JsonSerializer.Serialize(jsonObject);
                }
            }

            return result;
        }

        public string StartConversationToCarter(string apiKey, string uuid, string scene)
        {
            Console.WriteLine("Message to carter: ");
            string result = "";
            string tid = "";
            string message = Console.ReadLine();
            result = SendMessageInConversaition(apiKey, message, uuid);

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(result);

            result = jsonObject["output"].text.ToString();
            tid = jsonObject["tid"].ToString();

            Console.WriteLine(result);


            while (true)
            {
                Console.WriteLine("Message to carter: ");
                message = Console.ReadLine();

                if (message == "exit")
                {
                    return "Exited.";
                }

                if (message == "downvote")
                {
                    Console.WriteLine("Downvoted the message: " + result);
                    Downvote(tid, apiKey);
                    message = "";
                }

                if (message != "")
                {
                    result = SendMessageInConversaition(apiKey, message, uuid);

                    jsonObject = JsonConvert.DeserializeObject<dynamic>(result);

                    result = jsonObject["output"].text.ToString();
                    tid = jsonObject["tid"].ToString();

                    Console.WriteLine(result);
                }
            }
        }

        public string StartConversationToCarter(string apiKey, string uuid)
        {
            Console.WriteLine("Message to carter: ");
            string result = "";
            string tid = "";
            string message = Console.ReadLine();
            result = SendMessageInConversaition(apiKey, message, uuid);

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(result);

            result = jsonObject["output"].text.ToString();
            tid = jsonObject["tid"].ToString();

            Console.WriteLine(result);


            while (true)
            {
                Console.WriteLine("Message to carter: ");
                message = Console.ReadLine();

                if (message == "exit")
                {
                    return "Exited.";
                }

                if (message == "downvote")
                {
                    Console.WriteLine("Downvoted the message: " + result);
                    Downvote(tid, apiKey);
                    message = "";
                }

                if (message != "")
                {
                    result = SendMessageInConversaition(apiKey, message, uuid);

                    jsonObject = JsonConvert.DeserializeObject<dynamic>(result);

                    result = jsonObject["output"].text.ToString();
                    tid = jsonObject["tid"].ToString();

                    Console.WriteLine(result);
                }
            }
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

        public void Downvote(string downvotedMessageID, string apiKEY)
        {

        }
    }
}