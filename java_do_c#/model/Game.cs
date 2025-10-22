using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java_do_c_.model
{
    public class Game
    {
        private string name;
        public string GetName() => name;
        public int numberCount { get; }
        public int minRange { get; }
        public int maxRange{ get; }

        private List<int> results = new List<int>();
        public List<int> GetResults() => new List<int>(results);

        public Game(string _gameName, int _numbersCount, int _minRange, int _maxRange)
        {
            name = _gameName;
            numberCount = _numbersCount;
            minRange = _minRange;
            maxRange = _maxRange;
        }

        public void generateNumbers()
        {
            Random random = new Random();
            int _numberCount = 0;

            while(numberCount > _numberCount)
            {
                int rand = random.Next(minRange, maxRange + 1);

                if (!results.Contains(rand))
                {
                    results.Add(rand);
                    _numberCount++;
                }
            }
            results.Sort();
        }

        public class InvalidGameParametersException : Exception
        {
            public InvalidGameParametersException(string message) : base(message) { }
        }

    }
}
