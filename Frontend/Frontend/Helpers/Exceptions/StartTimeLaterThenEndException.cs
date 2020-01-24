using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartTimeLaterThenEndException : Exception
{
    public TimeSpan StartTime { get; }
    public TimeSpan EndTime { get; }


    public StartTimeLaterThenEndException(){}

    public StartTimeLaterThenEndException(string message) : base(message){}

    public StartTimeLaterThenEndException(string message, Exception inner) : base(message, inner){}

    public StartTimeLaterThenEndException(string message, TimeSpan startTime, TimeSpan endTime) : base(message) {
        StartTime = startTime;
        EndTime = endTime;
    }

}
