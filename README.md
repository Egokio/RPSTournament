# Rock Paper Scissors Tournament

A WPF desktop application for playing a five-round Rock Paper Scissors tournament against the computer.

## Project Structure

The solution contains two projects:

* **RPSTournament** — WPF application with the user interface and tournament control.
* **RPSTournament.Core** — Class Library containing the game logic and data types.

## Features

* Player name validation: 2–30 characters.
* Player can choose Rock, Paper, or Scissors.
* Computer chooses a move randomly.
* Each round is displayed in a DataGrid.
* The tournament consists of 5 rounds.
* Player and computer scores are tracked.
* The winner is displayed after the fifth round.
* A new tournament can be started at any time.
* Tournament history and scores are cleared when starting a new tournament.
* Validation messages are stored in `Resources.resx`.

## Core Components

The `RPSTournament.Core` project contains:

* `Move` enum — Rock, Paper, Scissors.
* `RoundResult` enum — Win, Lose, Draw.
* `GameRound` struct — stores information about a round.
* `GameLogic` class — generates the computer's move and determines the round result.

## Technologies

* C#
* .NET
* WPF
* Class Library
* Visual Studio

## How to Run

1. Open the solution in Visual Studio.
2. Make sure `RPSTournament` is set as the startup project.
3. Build the solution.
4. Run the application.

## How to Play

1. Enter a player name.
2. Select Rock, Paper, or Scissors.
3. Click **Play Round**.
4. Repeat until 5 rounds have been played.
5. The tournament result will be displayed after the fifth round.
6. Click **New Tournament** to clear the results and start again.
