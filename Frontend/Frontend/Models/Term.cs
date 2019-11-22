using System;
using System.Collections.Generic;

namespace Timetable
{
	public class Term
    {
        public long id { get; set; }
		public HashSet<Course> courses { get; set; }
        public DateTime dateStart { get; set; }
		public DateTime dateEnd { get; set; }
		public int period { get; set; }
    }
}