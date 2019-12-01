using System;
using Frontend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Frontend.Helpers
{
    /// <summary>
    /// The TermConverter class converts a json object of the type Term to a term object 
    /// and sets the variables if those are provided.
    /// </summary>
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
            Term term = new Term();
            try
            {
                JObject item = JObject.Load(reader);
                serializer.Populate(item.CreateReader(), term);
                return term;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
            }
            return term;

        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        }
    }
    /// <summary>
    /// The StudentConverter class converts a json object of the type Student to a set of students
    /// and sets the variables if those are provided.
    /// </summary>
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
            var students = new HashSet<Student>();
            try
            {
                var jArray = JArray.Load(reader);
                foreach (var j in jArray)
                {
                    Student student = new Student();
                    serializer.Populate(j.CreateReader(), student);
                    students.Add(student);
                }
                return students;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
            }
            catch (Newtonsoft.Json.JsonSerializationException)
            {
            }
            return students;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        }
    }
    /// <summary>
    /// The Converter class converts a string of json objects to a university object.
    /// </summary>
    class Converter
    {
        public University ParseJson(string json)
        {
            University uni = JsonConvert.DeserializeObject<University>(json);
            return uni;
        }
    }
}