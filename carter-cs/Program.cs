using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

class CarterCS
{
    //api key hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw
    static void SendMessageToCarter(string apiKey, string message, string uuid, string scene = "level-1")
    {
        var url = "https://api.carterapi.com/v0/chat";
        var payload = JsonConvert.SerializeObject(new { api_key = apiKey, query = message, uuid = uuid, scene });
        var content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
        using (var client = new HttpClient())
        {
            var response = client.PostAsync(url, content).Result;
            var responseText = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseText);
        }
    }

    static public void Main(String[] args)
    {
        SendMessageToCarter("hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw", "Hello", "admin-1", "bombs_away");
    }
}