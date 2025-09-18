using System;
using Xunit;
using PomodoroTimer.Core;

namespace PomodoroTimer.Tests
{
    public class PomodoroEngineTests
    {
        [Fact]
        public void Start_Should_BeginInFocusState()
        {
            var mockTimer = new MockTimer();
            var engine = new PomodoroEngine(mockTimer);

            PomodoroState? state = null;
            engine.StateChanged += (s, t) => state = s;

            engine.Start();

            Assert.Equal(PomodoroState.Focus, state);
        }

        [Fact]
        public void FocusCycle_Should_TransitionToShortBreak()
        {
            var mockTimer = new MockTimer();
            var engine = new PomodoroEngine(mockTimer)
            {
                FocusDuration = TimeSpan.FromSeconds(1)
            };

            PomodoroState? state = null;
            engine.StateChanged += (s, t) => state = s;

            engine.Start();
            mockTimer.Tick(); // simula passagem do tempo

            Assert.Equal(PomodoroState.ShortBreak, state);
        }
    }
}
