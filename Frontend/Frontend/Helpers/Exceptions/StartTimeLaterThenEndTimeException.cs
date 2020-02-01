using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartTimeLaterThenEndTimeException : Exception
{
    public TimeSpan StartTime { get; }
    public TimeSpan EndTime { get; }


    public StartTimeLaterThenEndTimeException(){}

    public StartTimeLaterThenEndTimeException(string message) : base(message){}

    public StartTimeLaterThenEndTimeException(string message, Exception inner) : base(message, inner){}

    public StartTimeLaterThenEndTimeException(string message, TimeSpan startTime, TimeSpan endTime) : base(message) {
        StartTime = startTime;
        EndTime = endTime;
    }

}
