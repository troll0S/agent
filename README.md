# Genetic Algorithm – Function Optimisation

A Windows Forms application in C# that finds the maximum of a function using a genetic algorithm, with charts of the population over generations and an automated parameter testing module. Created during the *Intelligent Agent Systems* (ISA) course labs.

<!-- Add a screenshot of the chart here, e.g. ![Chart](docs/chart.png) -->

## What it does

The algorithm maximises the function

```
f(x) = (x mod 1) · (cos(20πx) − sin(x))
```

on a user-defined interval `[a, b]` with precision `d`.

- **Binary encoding:** each individual is encoded as a bit string whose length follows from the interval and the precision
- **Roulette-wheel selection** based on fitness
- **Single-point crossover** with probability `pk`
- **Bit mutation** with probability `pn`
- **Elitism** (optional): the best individual always survives to the next generation
- **Chart:** minimum, average and maximum fitness for each generation

## Parameter testing

The *testy* module runs a grid search over the algorithm's parameters:

- population size `N`: 30–80
- number of generations `T`: 50–100
- crossover probability `pk`: 0.50–0.90
- several mutation probabilities `pn`

Each combination is run 100 times and the average best result is recorded. The combinations run in parallel (`Parallel.ForEach`), and the results are sorted to show the best parameter sets.

## Tech stack

C# · .NET Framework 4.7.2 · Windows Forms · System.Windows.Forms.DataVisualization (charts) · Task Parallel Library

## Getting started

1. Open `lab2/lab1.sln` in Visual Studio (Windows).
2. Build and run (F5).
3. Enter `a`, `b`, `d`, `N`, `T`, `pk`, `pn`, choose elitism and click **oblicz**; **wykres** shows the chart, **testy** runs the parameter tests.

## Project structure

| File | Responsibility |
| --- | --- |
| `Pokolenie.cs` | One generation: evaluation, selection, crossover, mutation, elitism |
| `BasicMaths.cs` | Encoding and decoding (real ↔ integer ↔ binary), fitness function |
| `Calculations.cs` | Selection probabilities and random draws |
| `Tests.cs` | Parallel parameter grid search |
| `Form1.cs`, `resultForm.cs` | GUI, results table and charts |

## Author

Wojciech Jurek – [GitHub](https://github.com/troll0S) · [LinkedIn](https://www.linkedin.com/in/wojciech-jurek-825027339)
