using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var user = new User()
            {
                Id = 404,
                Email = "chernikov@gmail.com",
                UserName = "rollinx",
                Name = "Andrey",
                FirstName = "Andrey",
                MiddleName = "Alexandrovich",
                LastName = "Chernikov",
                Gender = User.GenderEnum.Male,
                PhotoAlbum = new List<Photo>()
                {
                    new Photo {
                        Id = 1, 
                        Name = "Я с инстаграммом"
                    },
                    new Photo {
                        Id = 2,
                        Name = "Я на фоне заниженного таза"
                    }
                }
            };

            var jsonUser = JsonConvert.SerializeObject(user);

            System.Console.Write(jsonUser);

            var jsonSource = "{\"id\":404,\"name\":\"Andrey\",\"first_name\":\"Andrey\",\"middle_name\":\"Alexandrovich\",\"last_name\":\"Chernikov\",\"user_name\":\"rollinx\",\"gender\":\"M\",\"email\":\"chernikov@gmail.com\",\"photo_album\":[{\"id\":1,\"name\":\"Я с инстаграммом\"},{\"id\":2,\"name\":\"Я на фоне заниженного таза\"}]}";

            var user2 = JsonConvert.DeserializeObject<User>(jsonSource);
            System.Console.ReadLine();
        }
    }
}
