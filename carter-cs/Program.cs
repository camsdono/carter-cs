using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

string url = "https://api.carterapi.com/v0/chat";

var payload = JsonConvert.SerializeObject(new
{
    api_key = "hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw",
    query = "Hello there",
    uuid = "admin-1",
    scene = "bombs_away" // optional!
});

var client = new HttpClient();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
var response = await client.PostAsync(url, httpContent);

Console.WriteLine(await response.Content.ReadAsStringAsync());