using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Console
{
    [JsonObject]
    public class User
    {
        [JsonConverter(typeof(GenderEnumConverter))]
        public enum GenderEnum 
        {
            Male,
            Female
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("gender")]
        public GenderEnum Gender { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("photo_album")]
        public List<Photo> PhotoAlbum { get; set; }
    }
}
