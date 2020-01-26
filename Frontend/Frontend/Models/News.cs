using Frontend.Helpers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class News
    {
       public long id;
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonIgnore]
        public String Time
        {
            get
            {
                DateTime conv = TimestampToDatetimeConverter.convert(Timestamp);
                DateTime today = DateTime.Now;
                StringBuilder sb = new StringBuilder();
                if (conv.Day == today.Day)
                {
                    sb.Append("Heute, ");
                }
                else if (conv.Day == today.Day - 1)
                {
                    sb.Append("Gestern, ");
                }
                else
                {
                    sb.Append(conv.ToShortDateString()).Append(", ");
                }
                sb.Append(conv.ToShortTimeString()).Append("Uhr").Append(":");

                return sb.ToString();
            }
            set
            {
                Time = (string)value;
            }
        }
    }
}
