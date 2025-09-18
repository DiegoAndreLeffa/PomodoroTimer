using System;

namespace PomodoroTimer.Core
{
    public class PomodoroEngine
    {
        private readonly ITimer _timer;
        private int _completedFocusSessions = 0;

        public TimeSpan FocusDuration { get; set; } = TimeSpan.FromMinutes(25);
        public TimeSpan ShortBreakDuration { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan LongBreakDuration { get; set; } = TimeSpan.FromMinutes(15);

        public PomodoroState CurrentState { get; private set; } = PomodoroState.Focus;
        public TimeSpan TimeRemaining { get; private set; }

        public event Action<PomodoroState, TimeSpan>? StateChanged;

        public PomodoroEngine(ITimer timer)
        {
            _timer = timer;
            _timer.Elapsed += OnTimerElapsed;
        }

        public void Start()
        {
            SetState(PomodoroState.Focus, FocusDuration);
        }

        private void OnTimerElapsed()
        {
            TimeRemaining -= TimeSpan.FromSeconds(1);

            if (TimeRemaining <= TimeSpan.Zero)
            {
                switch (CurrentState)
                {
                    case PomodoroState.Focus:
                        _completedFocusSessions++;
                        if (_completedFocusSessions % 4 == 0)
                            SetState(PomodoroState.LongBreak, LongBreakDuration);
                        else
                            SetState(PomodoroState.ShortBreak, ShortBreakDuration);
                        break;

                    case PomodoroState.ShortBreak:
                    case PomodoroState.LongBreak:
                        SetState(PomodoroState.Focus, FocusDuration);
                        break;
                }
            }
            else
            {
                StateChanged?.Invoke(CurrentState, TimeRemaining);
            }
        }

        private void SetState(PomodoroState state, TimeSpan duration)
        {
            CurrentState = state;
            TimeRemaining = duration;
            StateChanged?.Invoke(CurrentState, TimeRemaining);
            _timer.Start(TimeSpan.FromSeconds(1));
        }
    }
}
