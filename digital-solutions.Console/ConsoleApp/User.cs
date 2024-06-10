using System.Text;
using Newtonsoft.Json;

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
                Console.WriteLine($"'{usuario}' posted -> {mensaje}'.");            // Falta agregar hora de envio
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

    public async Task Dashboard()
    {
        throw new NotImplementedException();
    }
}