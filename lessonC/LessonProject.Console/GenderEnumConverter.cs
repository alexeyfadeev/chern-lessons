using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Console
{
    public class GenderEnumConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, 
            Type objectType,
            object existingValue, 
            JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            if (string.Compare(value, "M", true) == 0)
            {
                return User.GenderEnum.Male;
            }
            if (string.Compare(value, "F", true) == 0)
            {
                return User.GenderEnum.Female;
            }
            return  User.GenderEnum.Male;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (User.GenderEnum)value;

            // Write associative array field name
            writer.WriteValue(value.ToString().Substring(0,1));
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
