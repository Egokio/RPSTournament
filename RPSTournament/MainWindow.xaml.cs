using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RPSTournament.Core;
using RPSTournament;

namespace RPSTournament
{
    public partial class MainWindow : Window
    {
        private const int MaxRounds = 5;

        private int currentRound = 0;
        private int playerScore = 0;
        private int computerScore = 0;

        private readonly List<GameRound> rounds = new List<GameRound>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PlayRound_Click(object sender, RoutedEventArgs e)
        {
            // Check player name
            string playerName = NameBox.Text.Trim();

            if (playerName.Length < 2 || playerName.Length > 30)
            {
                MessageBox.Show(
                    global::RPSTournament.Resources.InvalidName,
                    "Invalid name",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            // Check selected move
            if (MoveBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    global::RPSTournament.Resources.MoveNotSelected,
                    "Move not selected",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            // Check number of rounds
            if (currentRound >= MaxRounds)
            {
                MessageBox.Show(
                    "The tournament is already finished.",
                    "Tournament finished",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            // Get player move
            Move playerMove = MoveBox.SelectedIndex switch
            {
                0 => Move.Rock,
                1 => Move.Paper,
                _ => Move.Scissors
            };

            // Get computer move
            Move computerMove = GameLogic.GetComputerMove();

            // Get result
            RoundResult result =
                GameLogic.GetRoundResult(playerMove, computerMove);

            // Increase round
            currentRound++;

            // Update score
            if (result == RoundResult.Win)
            {
                playerScore++;
            }
            else if (result == RoundResult.Lose)
            {
                computerScore++;
            }

            // Save round
            GameRound round = new GameRound
            {
                Number = currentRound,
                PlayerMove = playerMove,
                ComputerMove = computerMove,
                Result = result
            };

            rounds.Add(round);

            // Update DataGrid
            RoundsGrid.ItemsSource = null;
            RoundsGrid.ItemsSource = rounds;

            // Update score
            ScoreText.Text =
                $"Round: {currentRound}/{MaxRounds}    " +
                $"Score: {playerScore} - {computerScore}";

            // Check tournament end
            if (currentRound == MaxRounds)
            {
                string winner;

                if (playerScore > computerScore)
                {
                    winner = $"{playerName} wins the tournament!";
                }
                else if (computerScore > playerScore)
                {
                    winner = "Computer wins the tournament!";
                }
                else
                {
                    winner = "The tournament ends in a draw!";
                }

                MessageBox.Show(
                    winner,
                    "Tournament Result",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            // Clear selected move
            MoveBox.SelectedIndex = -1;
        }

        private void DataGrid_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
        }

        private void NewTournament_Click(object sender, RoutedEventArgs e)
        {
            currentRound = 0;
            playerScore = 0;
            computerScore = 0;

            rounds.Clear();

            RoundsGrid.ItemsSource = null;

            ScoreText.Text = "Score: 0 - 0";

            MoveBox.SelectedIndex = -1;
        }
    }
}