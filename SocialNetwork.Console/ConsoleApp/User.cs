using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace program;

public class User : IUserBehavior
{
    private string name;

    public string Nombre
    {
        get { return name; }
        set{name = value;}
    }

    public async Task Post( string mensaje,string usuario)
    {
        using (var client = new HttpClient())
        {
            string url = "http://localhost:5197/api/v1/status/";
            var postData = new { message = mensaje , user = usuario };
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                // Recibierndo createdDate
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic status = JsonConvert.DeserializeObject(responseContent);
                DateTime createdDate = DateTime.Parse(status.createdDate.ToString());
                // Mostrar en consola
                Console.WriteLine($"'{usuario}' posted -> {mensaje}' @ {createdDate.TimeOfDay}.");            // Falta agregar hora de envio
            }
            else
            {
                Console.WriteLine($"Error al publicar el mensaje: {response.StatusCode}");
            }
        }
    }

    public async Task Follow(string follower, string followed)
    {
        using (var client = new HttpClient())
        {
            string url = "http://localhost:5197/api/v1/following-interactions/";
            var postData = new { follower = follower, followed = followed };
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{follower} empezo a seguir a {followed}");
            }
            else
            {
                Console.WriteLine($"Error al seguir a {followed}: {response.StatusCode}");
            }
        }
    }

    public async Task Dashboard(string follower)
    {
        using (var client = new HttpClient())
        {
            string url = $"http://localhost:5197/api/v1/following-interactions/follower/{follower}";
            client.DefaultRequestHeaders.Clear();
            var response = client.GetAsync(url).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            dynamic r = JArray.Parse(res);
            //Lista para almacenar personas seguidas
            List<string> followedList = new List<string>();
           //Guardando las personas a las que ha seguido
            foreach (JObject item in r)
            {
                string followed = (string)item["followed"];
                followedList.Add(followed);
            }
            
            //Obteniendo status de las personas seguidas
            //falta agregar fechas
            foreach (var followed in followedList)
            {
                string url2 = $"http://localhost:5197/api/v1/status/{followed}"; 
                client.DefaultRequestHeaders.Clear();
                 var response2 = client.GetAsync(url2).Result;
                 var res2 = response2.Content.ReadAsStringAsync().Result;
                 dynamic r2= JArray.Parse(res2);
                 
                 foreach ( JObject item in r2)
                 {
                     string message = (string)item["message"];
                     DateTime createdDate = DateTime.Parse(item["createdDate"].ToString());
                     Console.WriteLine($"\" {message}\" @{followed} @ {createdDate.TimeOfDay}");
                 }
                            
            }
            // Recibierndo createdDate
            // var responseContent = await response.Content.ReadAsStringAsync();
            // dynamic status = JsonConvert.DeserializeObject(responseContent);
            // DateTime createdDate = DateTime.Parse(status.createdDate.ToString());

        
        }
    }
}