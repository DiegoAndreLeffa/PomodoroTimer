# PomodoroTimer

Um cronômetro/timer de **Pomodoro** em C#, pensado para ser simples, testável e fácil de estender. Projeto de exemplo com separação entre **Core** (lógica), **UI** (console) e **Tests** (xUnit).

---

## ✅ Funcionalidades

* Ciclo Pomodoro: Focus → Short Break → Long Break.
* Contador de sessões focadas (long break após 4 sessões).
* Abstração de timer para facilitar testes (interface `ITimer`).
* Interface simples em console com spinner e alerta sonoro (`Console.Beep()`).
* Testes unitários para transições de estado.

---

## 📁 Estrutura do projeto

```
/src
  /PomodoroTimer.Core      # biblioteca com lógica (PomodoroEngine, ITimer, etc.)
  /PomodoroTimer.UI        # app console (Program.cs)
  /PomodoroTimer.Tests     # testes unitários (xUnit)
README.md
```

---

## 🔧 Pré-requisitos

* .NET SDK (6/7/8 — compatível com a sua versão)
* Git
* Editor (VS Code recomendado)

---

## 🚀 Como executar (localmente)

1. Clonar repositório:

```bash
git <[clone](https://github.com/DiegoAndreLeffa/PomodoroTimer.git)>
cd PomodoroTimer
```

2. Restaurar dependências (opcional — o `dotnet run` faz isso automaticamente):

```bash
dotnet restore
```

3. Rodar o app (console):

```bash
dotnet run --project src/PomodoroTimer.UI
```

Você verá o estado e o tempo restante atualizados no console com um pequeno spinner. Ao final de cada período, um `Console.Beep()` será executado.

---

## 🧪 Executar testes

```bash
dotnet test
```

Os testes usam um `MockTimer` para controlar manualmente o avanço do tempo e validar as transições do `PomodoroEngine`.

---

## 💡 Boas práticas e notas do projeto

* A abstração `ITimer` torna fácil testar comportamento temporal sem depender de timers reais.
* Seguir o fluxo `main` (estável) / `develop` (desenvolvimento) / `feature/*` para novas funcionalidades.
* Use commits com mensagens claras (ex: `feat(core): adicionar engine de pomodoro`, `test: adicionar testes de transição`).
