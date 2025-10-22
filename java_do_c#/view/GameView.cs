using System;
using LottoGameApp.Model;

namespace LottoGameApp.View
{
    /// <summary>
    /// Handles all user interface operations for the Lotto Game application.
    /// </summary>
    /// <remarks>
    /// This class is responsible for displaying game results, error messages,
    /// and prompting users for input. It follows the MVC pattern as the View component.
    /// </remarks>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class GameView
    {
        #region Public Methods

        /// <summary>
        /// Displays the results of a completed game.
        /// </summary>
        /// <param name="game">The game object containing the results to display.</param>
        /// <remarks>
        /// Outputs the game name followed by the generated numbers separated by spaces.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when game parameter is null.</exception>
        public void DisplayResults(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game), "Game object cannot be null.");
            }

            Console.WriteLine(game.GameName);

            var numbers = game.GeneratedNumbers;
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Count - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <remarks>
        /// Outputs the error message to the standard error stream with "Error: " prefix.
        /// </remarks>
        public void DisplayError(string message)
        {
            Console.Error.WriteLine($"Error: {message}");
        }

        /// <summary>
        /// Prompts the user to enter a game type.
        /// </summary>
        /// <remarks>
        /// Displays available game types to help the user make a selection.
        /// </remarks>
        public void PromptForGameType()
        {
            Console.WriteLine("Enter game type (lotto, multimulti, minilotto):");
        }

        /// <summary>
        /// Displays a welcome message to the user.
        /// </summary>
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("=== Lotto Game Application ===");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays available game types and their configurations.
        /// </summary>
        public void DisplayAvailableGames()
        {
            Console.WriteLine("Available games:");
            Console.WriteLine("  - lotto:      6 numbers from 1 to 49");
            Console.WriteLine("  - multimulti: 10 numbers from 1 to 80");
            Console.WriteLine("  - minilotto:  5 numbers from 1 to 42");
            Console.WriteLine();
        }

        #endregion
    }
}