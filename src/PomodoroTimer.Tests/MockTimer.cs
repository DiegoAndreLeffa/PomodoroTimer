using System;
using PomodoroTimer.Core;

namespace PomodoroTimer.Tests
{
    public class MockTimer : Core.ITimer
    {
        public event Action? Elapsed;

        public void Start(TimeSpan interval) { }
        public void Stop() { }
        public void Dispose() { }

        // dispara manualmente o evento
        public void Tick()
        {
            Elapsed?.Invoke();
        }
    }
}
