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


        [JsonProperty("fromGroupsID")]
        public long fromGroupsID { get; set; }
        [JsonProperty("toGroupsID")]
        public long[] toGroupsID { get; set; }

        public SwapOffer(long fromGroup, long toGroup)
        {
            // this.course = course;
            this.fromGroupsID = fromGroup;
            this.toGroupsID = new long[] { toGroup };
        }
    }
}