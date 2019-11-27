using System;
using Frontend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//TODO: Documentation WIKI + Code
namespace Frontend.Helpers

{
    class TermConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject item = JObject.Load(reader);
                var term = new Term();
                serializer.Populate(item.CreateReader(), term);
                return term;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
          
            }
            Term t = new Term();
            return t;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        }
    }

    class StudentConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject item = JObject.Load(reader);
                var student = new Student();
                serializer.Populate(item.CreateReader(), student);
                return student;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {

            }
            Student s = new Student();
            return s;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        }
    }

    class Converter
    {
        public University ParseJson(string json)
        {
            University uni = JsonConvert.DeserializeObject<University>(json);
            return uni;
        }
    }
}
