using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public class Term
    {
        public long Id { get; set; }
        public string StartDate { get; set; } //convert string to datetime
		public string EndDate { get; set; }
		public int Period { get; set; }
    }
}