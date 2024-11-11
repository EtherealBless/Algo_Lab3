using System.Diagnostics;

namespace Lab3
{
    class Timer
    {
        static private TimeSpan Time(Action action)
        {
            var stopwatch = new Stopwatch(); 

            stopwatch.Start();
            action();
            stopwatch.Stop();

            return new TimeSpan(stopwatch.ElapsedTicks);
        }

        static public string MeasureTime(Action action) => Time(action).TotalMilliseconds + " ms.";
    }
}
