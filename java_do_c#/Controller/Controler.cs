using System;
using LottoGameApp.Model;
using LottoGameApp.View;

namespace LottoGameApp.Controller
{
    /// <summary>
    /// Controls the application flow and coordinates between Model and View.
    /// </summary>
    /// <remarks>
    /// This class implements the Controller component of the MVC pattern.
    /// It processes command line arguments, handles user input, creates game instances,
    /// and manages exception handling for invalid game configurations.
    /// </remarks>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class GameController
    {
        #region Private Fields

        /// <summary>
        /// The view component for user interface operations.
        /// </summary>
        private readonly GameView _view;

        /// <summary>
        /// The current game instance.
        /// </summary>
        private Game _game;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the GameController class.
        /// </summary>
        /// <remarks>
        /// Creates and initializes the view component.
        /// </remarks>
        public GameController()
        {
            _view = new GameView();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Runs the main application logic.
        /// </summary>
        /// <param name="args">Command line arguments passed to the application.</param>
        /// <remarks>
        /// Processes command line arguments to determine game type.
        /// If no arguments provided, prompts user for input.
        /// Handles InvalidGameConfigurationException thrown by the model.
        /// Expected argument format: args[0] = game type identifier.
        /// </remarks>
        public void Run(string[] args)
        {
            try
            {
                _view.DisplayWelcomeMessage();

                string gameType;

                // Determine game type from arguments or user input
                if (args != null && args.Length > 0)
                {
                    gameType = args[0].ToLower().Trim();
                }
                else
                {
                    gameType = GetUserInput();
                }

                // Create and run the game
                if (CreateGame(gameType))
                {
                    _game.GenerateNumbers();
                    _view.DisplayResults(_game);
                }
                else
                {
                    _view.DisplayError($"Unknown game type: {gameType}");
                    _view.DisplayAvailableGames();
                }
            }
            catch (InvalidGameConfigurationException ex)
            {
                // Handle custom exception from model
                _view.DisplayError($"Invalid game configuration: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                _view.DisplayError($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets game type input from the user via console.
        /// </summary>
        /// <returns>The game type entered by the user, converted to lowercase and trimmed.</returns>
        /// <remarks>
        /// Displays available games and prompts the user for input.
        /// </remarks>
        private string GetUserInput()
        {
            _view.DisplayAvailableGames();
            _view.PromptForGameType();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            return input.ToLower().Trim();
        }

        /// <summary>
        /// Creates a game instance based on the specified game type.
        /// </summary>
        /// <param name="gameType">The type of game to create (case-insensitive).</param>
        /// <returns>
        /// True if the game was successfully created; false if the game type is not recognized.
        /// </returns>
        /// <exception cref="InvalidGameConfigurationException">
        /// Thrown when game parameters are invalid during game creation.
        /// </exception>
        /// <remarks>
        /// Supported game types:
        /// - "lotto": Standard Lotto (6 numbers from 1-49)
        /// - "multimulti": MultiMulti (10 numbers from 1-80)
        /// - "minilotto": Mini Lotto (5 numbers from 1-42)
        /// </remarks>
        private bool CreateGame(string gameType)
        {
            switch (gameType)
            {
                case "lotto":
                    _game = new Game("Lotto", 6, 1, 49);
                    return true;

                case "multimulti":
                    _game = new Game("MultiMulti", 10, 1, 80);
                    return true;

                case "minilotto":
                    _game = new Game("Mini Lotto", 5, 1, 42);
                    return true;

                default:
                    return false;
            }
        }

        #endregion
    }
}