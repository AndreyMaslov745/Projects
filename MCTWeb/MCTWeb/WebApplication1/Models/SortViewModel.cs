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
        public int FirstSorted { get; set; }
        public int LastSorted { get; set; }
        public int FirstUnSorted { get; set; }
        public int LastUnSorted { get; set; }

        public SortViewModel(string sortName, int[] array, Func<int[], int[]>  func)
        {
            SortName = sortName;
            FirstUnSorted = array[0];
            LastUnSorted = array[array.Length - 1];
            var watch = new Stopwatch();
            watch.Start();
            var sorted = func(array);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            SortingTime = ts;
            FirstSorted = sorted[0];
            LastSorted = sorted[array.Length - 1];

        }
    }
}
