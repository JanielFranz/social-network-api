//
// using Newtonsoft.Json.Linq;
//
// using (var client = new HttpClient())
// {
//     string url = "http://localhost:5197/api/v1/status/Pepe";
//     client.DefaultRequestHeaders.Clear();
//     var response = client.GetAsync(url).Result;
//     var res = response.Content.ReadAsStringAsync().Result;
//     dynamic r = JArray.Parse(res);
//     
//     foreach (JObject item in r)
//     {
//         string message = (string)item["message"];
//         Console.WriteLine(message);
//     }
// }


namespace program;

class program
{
    static void Main(string[] args)
    {
        User userAlfonso = new User();
        userAlfonso.Nombre = "Alfonso";

        User userIvan = new User();
        userIvan.Nombre = "Ivan";

        User userAlicia = new User();
        userAlicia.Nombre = "Alicia";

        // Mapear los nombres de usuario a las instancias de User
        var users = new Dictionary<string, User>
        {
            { "Alfonso", userAlfonso },
            { "Ivan", userIvan },
            { "Alicia", userAlicia }
        };

        Console.Write("RED SOCIAL :) \n");

        //App menu
        while (true)
        {
            string comando = Console.ReadLine();
            // Analizar el comando
            if (comando.StartsWith("post "))
            {
                var parts = comando.Split(' ', 3); // Dividir el comando en partes
                if (parts.Length < 3)
                {
                    Console.WriteLine("Formato de comando incorrecto. Usa: post @usuario mensaje");
                    continue;
                }

                var usuario = parts[1].Substring(1); // Obtener el nombre del usuario (sin el @)
                var mensaje = parts[2]; // Obtener el mensaje

                // Buscar el usuario
                if (!users.TryGetValue(usuario, out var user))
                {
                    Console.WriteLine($"Usuario '{usuario}' no encontrado.");
                    continue;
                }

                // Publicar el mensaje
                user.Post(mensaje, usuario).Wait(); // Esperar a que la tarea se complete
            }
            else if (comando.StartsWith("follow"))
            {
                var parts = comando.Split(' ', 3);
                if (parts.Length < 3)
                {
                    Console.WriteLine("Formato de comando incorrecto. Usa: follow @usuario @usuario");
                    continue;
                }

                var follower = parts[1].Substring(1);
                var followed = parts[2].Substring(1);

                if (!users.TryGetValue(follower, out var userFollower))
                {
                    Console.WriteLine($"usuario '{follower}' no encontrado.");
                    continue;
                }

                if (!users.TryGetValue(followed, out var userFollowed))
                {
                    Console.WriteLine($"usuario a seguir '{followed}' no encontrado.");
                    continue;
                }
                //Seguir
                userFollower.Follow(follower, followed).Wait();
            }
            
            //Dashboard 
            
            else if (comando.StartsWith("dashboard"))
            {
                var parts = comando.Split(' ', 2);
                if (parts.Length < 2)
                {
                    Console.WriteLine("Formato de comando incorrecto. Usa: dashboard @usuario");
                    continue;
                }

                var follower = parts[1].Substring(1);

                if (!users.TryGetValue(follower, out var userFollower))
                {
                    Console.WriteLine($"El usuario '{follower} no ha sido encontrado");
                    continue;
                }

                userFollower.Dashboard(follower).Wait();

            }
            
            
            // ... resto del código ...
        }
    }
}


























//
// class program
// {
//     static void Main(string[] args)
//     {
//         User userAlfonso = new User();
//         userAlfonso.Nombre = "Alfonso";
//
//         User userIvan = new User();
//         userIvan.Nombre = "Ivan";
//
//         User userAlicia = new User();
//         userAlicia.Nombre = "Alicia";
//         //Console.WriteLine(userAlicia.Nombre);
//
//
//         Console.Write("RED SOCIAL :) \n");
//         Console.Write(userAlicia.Nombre);
//         //App menu
//         while (true)
//         {
//             string comando = Console.ReadLine();
//             // Analizar el comando
//             if (comando.StartsWith("post "))
//             {
//                 // Si el comando comienza con "post ", ejecutar la acción de publicación
//                 string mensaje = comando.Substring(5); // Obtener el mensaje después de "post "
//                 Console.WriteLine($" posted: {mensaje}");
//                 
//                 
//                 // Aquí podrías realizar cualquier acción adicional, como enviar el mensaje a un servicio, etc.
//             }
//
//             else if (comando.StartsWith("follow "))
//             {
//                 string mensaje = comando.Substring(5); 
//                 Console.WriteLine($"X empezo a seguir a: {mensaje}");
//                 //Hace validacion de que la persona a la que estoy siguiendo exista.
//             }
//
//             else if (comando.StartsWith("dashboard "))
//             {
//
//                 string mensaje = comando.Substring(5); 
//                 Console.WriteLine($"Cositas del dashboard");
//
//             }
//             else
//             {
//                 Console.WriteLine("Comando no reconocido.");
//                 // Si el comando no es reconocido, mostrar un mensaje de error
//
//             }
//             
//         }
//
//     }
// }