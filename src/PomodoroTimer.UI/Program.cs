using PomodoroTimer.Core;
using System;
using System.Threading;

class Program
{
    private static readonly string[] Spinner = { "|", "/", "-", "\\" };
    private static int spinnerIndex = 0;

    static void Main(string[] args)
    {
        using var timer = new SystemTimer();
        var engine = new PomodoroEngine(timer);

        engine.StateChanged += (state, time) =>
        {
            Display(state, time);
            if (time == TimeSpan.Zero)
                Console.Beep(); // alerta sonoro simples
        };

        Console.WriteLine("Iniciando Pomodoro...");
        engine.Start();

        // Mantém o programa rodando
        Thread.Sleep(Timeout.Infinite);
    }

    private static void Display(PomodoroState state, TimeSpan time)
    {
        var spinnerChar = Spinner[spinnerIndex];
        spinnerIndex = (spinnerIndex + 1) % Spinner.Length;

        Console.Write($"\r[{spinnerChar}] {state} - {time:mm\\:ss}   ");
    }
}
