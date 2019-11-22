using System;
using System.Collections.Generic;

namespace Timetable
{
	public class Term
    {
        public long Id { get; set; }
		public HashSet<Course> Courses { get; set; }
        public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public int Period { get; set; }
    }
}