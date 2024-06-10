
using Newtonsoft.Json.Linq;

using (var client = new HttpClient())
{
    string url = "http://localhost:5197/api/v1/status/Pepe";
    client.DefaultRequestHeaders.Clear();
    var response = client.GetAsync(url).Result;
    var res = response.Content.ReadAsStringAsync().Result;
    dynamic r = JArray.Parse(res);
    
    foreach (JObject item in r)
    {
        string message = (string)item["message"];
        Console.WriteLine(message);
    }
}