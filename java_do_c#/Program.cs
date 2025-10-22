using LottoGameApp.Controller;

namespace LottoGameApp
{
    /// <summary>
    /// Main program class that serves as the entry point for the Lotto Game application.
    /// </summary>
    /// <remarks>
    /// This class initializes the controller and starts the application.
    /// Command line arguments can be passed to specify game type:
    /// - "lotto" - Standard Lotto game (6 numbers from 1-49)
    /// - "multimulti" - MultiMulti game (10 numbers from 1-80)
    /// - "minilotto" - Mini Lotto game (5 numbers from 1-42)
    /// If no arguments are provided, the application will prompt the user for input.
    /// </remarks>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">
        /// Command line arguments. 
        /// Expected format: args[0] = game type ("lotto", "multimulti", or "minilotto")
        /// </param>
        /// <remarks>
        /// Parameter order:
        /// 1. args[0] (optional) - Game type identifier (case-insensitive)
        /// If no parameters provided, application enters interactive mode.
        /// </remarks>
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.Run(args);
        }
    }
}