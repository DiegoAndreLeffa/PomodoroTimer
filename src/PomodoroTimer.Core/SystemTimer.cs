using System;

namespace PomodoroTimer.Core
{
    public class SystemTimer : ITimer
    {
        private readonly System.Timers.Timer _timer;
        public event Action? Elapsed;

        public SystemTimer()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += (sender, args) => Elapsed?.Invoke();
        }

        public void Start(TimeSpan interval)
        {
            _timer.Interval = interval.TotalMilliseconds;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
