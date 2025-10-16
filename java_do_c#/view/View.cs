using java_do_c_.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java_do_c_.view
{
    public class View
    {
        public void displayResults(Game game)
        {
            Console.WriteLine(game.name);

            foreach(int i in game.results)
            {
                Console.Write($"{i} ");
            }
        }
        public void askForGameType()
        {
            Console.WriteLine("w jaki typ gry chcesz zagrać");
        }

    }
}
