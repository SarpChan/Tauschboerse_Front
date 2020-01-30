using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOffer
    {


        [JsonProperty("fromGroup")]
        public long FromGroupID { get; set; }
        [JsonProperty("toGroup")]
        public long[] ToGroupID { get; set; }

        public SwapOffer(long fromGroup, long toGroup)
        {
            // this.course = course;
            this.FromGroupID = fromGroup;
            this.ToGroupID = new long[] { toGroup, };
        }
    }
}