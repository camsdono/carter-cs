using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

string url = "https://api.carterapi.com/v0/chat";

async void ReachCarter(string apiKey, string carterMessage, string userID, string sceneName) 
{
    var payload = JsonConvert.SerializeObject(new
    {
        api_key = apiKey,
        query = carterMessage,
        uuid = userID,
        scene = sceneName
    });

    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
    var response = await client.PostAsync(url, httpContent);
    var json = await response.Content.ReadAsStringAsync();
    Console.WriteLine(json);
    var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);

    string result = jsonObject["output"].text.ToString();
    Console.WriteLine(result);
}

ReachCarter("hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw", "Hello", "admin-1", "bombs_away");


