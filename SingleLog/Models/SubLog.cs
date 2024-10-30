﻿using System.Text.Json.Serialization;
using System.Diagnostics;

namespace SingleLog.Models
{
    public class SubLog : IDisposable
    {
        public DateTime ExecutedAt { get; set; }

        public int TraceId { get; set; }

        public long ElapsedMilliseconds { get; set; }

        [JsonIgnore]
        internal Stopwatch StopwatchCronometer { get; set; }

        [JsonIgnore]
        public Exception? Exception { get; set; }

        public SubLog()
        {
            ExecutedAt = DateTime.Now;
            StopwatchCronometer = new Stopwatch();

            StartCronometer();
        }

        public void StartCronometer()
        {
            if (StopwatchCronometer.IsRunning)
                StopwatchCronometer.Start();
        }

        public void StopCronometer()
        {
            StopwatchCronometer.Stop();
            ElapsedMilliseconds = StopwatchCronometer.ElapsedMilliseconds;
        }

        public void Dispose()
        {
            StopwatchCronometer.Stop();
        }
    }
}