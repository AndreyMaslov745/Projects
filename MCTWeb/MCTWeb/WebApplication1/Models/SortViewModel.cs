using System;
using System.Diagnostics;
using System.Globalization;
using WebApplication1.Extensions;

namespace WebApplication1.Models
{
    public class SortViewModel
    {
        public string SortName { get; init; }
        public TimeSpan SortingTime { get; init; }

        public SortViewModel(string sortName, int[] array, Func<int[], int[]>  func)
        {
            SortName = sortName;
            var watch = new Stopwatch();
            watch.Start();
            var sorted = func(array);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            SortingTime = ts;
        }
    }
}
