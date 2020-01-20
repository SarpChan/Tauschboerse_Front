/*using Frontend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Frontend.Helpers.JsonConverters
{
    [Obsolete("Wird nicht mehr benoetigt")]
    class JsonToGroupListConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Group>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var groupList = new List<Group>();
            var jsonArray = JArray.Load(reader);

            foreach (var json in jsonArray)
            {
                var group = new Group();
                serializer.Populate(json.CreateReader(), group); 
                groupList.Add(group);
            }
            /*
            foreach (Group g in groupList)
            {
                string start = new List<string>(g.StartTime.Keys)[0];
                string end = new List<string>(g.EndTime.Keys)[0];
                Console.WriteLine("group " + g.Id + " starts at " + start + " ends at " + g.EndTime.Keys);
            }
           
            return groupList;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<Group> groupList = value as List<Group>;
            writer.WriteStartArray();

            foreach (var group in groupList)
            {
                serializer.Serialize(writer, group);
            }
            writer.WriteEndArray();
        }
    }
}
*/
