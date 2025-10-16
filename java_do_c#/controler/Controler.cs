using java_do_c_.model;
using java_do_c_.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace java_do_c_.controler
{
    public class Controler
    {
        private View view = new View(); //mógłbym nie pisać private bo domyślnie wszytko jest private
        private Game game;

        public void run(string[] args)
        {

            //trzeba bedzie dorobic obsluge wielu arumentow i to ze jak program bez argumentow to jakies menu sie uruchamia

            string gameType;



            if (args != null && args.Length > 0)
            {
                gameType = args[0].ToLower();
            }
            else
            {
                gameType = getUserInput();
            }

            if (createGame(gameType))
            {
                game.generateNumbers();
                view.displayResults(game);
            }
        }


        private string getUserInput()
        {
            //view.askForGameType();
            string input = Console.ReadLine();// trim usuwa biale znaki

            input = input.ToLower().Trim();

            return input;
        }

        private bool createGame(string gameType)
        {
            switch (gameType)
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
    }
}
