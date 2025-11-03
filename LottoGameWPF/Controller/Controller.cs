using LottoWPF.model;
using System;

namespace LottoWPF.controller
{
    /// <summary>
    /// Controller class that manages the interaction between Model and View
    /// Handles game creation and number generation logic
    /// </summary>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class Controller
    {
        private MainWindow view;
        private Game game;

        /// <summary>
        /// Initializes the controller with a reference to the view
        /// </summary>
        /// <param name="view">Main window view instance</param>
        public Controller(MainWindow view)
        {
            this.view = view;
        }

        /// <summary>
        /// Generates numbers for the specified game type
        /// </summary>
        /// <param name="gameType">Type of game (lotto, multimulti, minilotto)</param>
        public void GenerateGame(string gameType)
        {
            try
            {
                if (CreateGame(gameType))
                {
                    game.GenerateNumbers();
                    DisplayResults();
                }
                else
                {
                    view.DisplayError($"Unknown game type: {gameType}");
                }
            }
            catch (InvalidGameException ex)
            {
                view.DisplayError($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                view.DisplayError($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a game instance based on the game type
        /// </summary>
        /// <param name="gameType">Type of game to create</param>
        /// <returns>True if game was created successfully, false otherwise</returns>
        /// <exception cref="InvalidGameException">Thrown when game parameters are invalid</exception>
        private bool CreateGame(string gameType)
        {
            switch (gameType.ToLower())
            {
                case "lotto":
                    game = new Game("Lotto", 6, 1, 49);
                    return true;
                case "multimulti":
                    game = new Game("MultiMulti", 10, 1, 80);
                    return true;
                case "minilotto":
                    game = new Game("Mini Lotto", 5, 1, 42);
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Formats and displays the game results in the view
        /// </summary>
        private void DisplayResults()
        {
            string numbers = string.Join("  ", game.Results);
            view.DisplayResults(game.Name, numbers);
        }
    }
}