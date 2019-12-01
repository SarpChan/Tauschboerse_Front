using System;
using Frontend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Frontend.Helpers
{
    class GroupConverter : JsonConverter
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
            var terms = new HashSet<Term>();
            var groups = new HashSet<Group>();
            var jArray = JArray.Load(reader);

            foreach (var j in jArray)
            {
                var group = new Group();
                serializer.Populate(j.CreateReader(), group);

                if (group.Term.TermIsSet)
                {
                    terms.Add(group.Term);
                }
                else
                {
                    foreach (var t in terms)
                    {
                        if (t.Id == group.Term.Id)
                        {
                            group.Term = t;

                        }
                    }
                }
                groups.Add(group);
            }
            return groups;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        }
    }
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
            var term = new Term();
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var test = reader.Value;
                    term.Id = (long)test;
                    break;
                case JsonToken.StartObject:
                    JObject item = JObject.Load(reader);
                    serializer.Populate(item.CreateReader(), term);
                    break;
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
                    var student = new Student();
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