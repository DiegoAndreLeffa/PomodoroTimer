using System;

namespace PomodoroTimer.Core
{
    public interface ITimer : IDisposable
    {
        event Action Elapsed;
        void Start(TimeSpan interval);
        void Stop();
    }
}
