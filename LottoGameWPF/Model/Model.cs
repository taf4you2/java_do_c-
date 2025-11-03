using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoWPF.model
{
    /// <summary>
    /// Represents a lottery game with configurable parameters
    /// Handles number generation and validation
    /// </summary>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class Game
    {
        private string name;
        private int numberCount;
        private int minRange;
        private int maxRange;
        private List<int> results;

        /// <summary>
        /// Gets the name of the game
        /// </summary>
        /// <returns>Game name</returns>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the count of numbers to generate
        /// </summary>
        /// <returns>Number count</returns>
        public int NumberCount
        {
            get { return numberCount; }
        }

        /// <summary>
        /// Gets the minimum range value
        /// </summary>
        /// <returns>Minimum range</returns>
        public int MinRange
        {
            get { return minRange; }
        }

        /// <summary>
        /// Gets the maximum range value
        /// </summary>
        /// <returns>Maximum range</returns>
        public int MaxRange
        {
            get { return maxRange; }
        }

        /// <summary>
        /// Gets the list of generated numbers
        /// </summary>
        /// <returns>List of generated numbers</returns>
        public List<int> Results
        {
            get { return new List<int>(results); } // Return copy for encapsulation
        }

        /// <summary>
        /// Initializes a new lottery game with specified parameters
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="numbersCount">How many numbers to generate</param>
        /// <param name="minRange">Minimum number in range</param>
        /// <param name="maxRange">Maximum number in range</param>
        /// <exception cref="InvalidGameException">Thrown when game parameters are invalid</exception>
        public Game(string gameName, int numbersCount, int minRange, int maxRange)
        {
            ValidateParameters(gameName, numbersCount, minRange, maxRange);

            this.name = gameName;
            this.numberCount = numbersCount;
            this.minRange = minRange;
            this.maxRange = maxRange;
            this.results = new List<int>();
        }

        /// <summary>
        /// Validates game parameters before creating the game
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="numbersCount">How many numbers to generate</param>
        /// <param name="minRange">Minimum number in range</param>
        /// <param name="maxRange">Maximum number in range</param>
        /// <exception cref="InvalidGameException">Thrown when parameters are invalid</exception>
        private void ValidateParameters(string gameName, int numbersCount, int minRange, int maxRange)
        {
            if (string.IsNullOrWhiteSpace(gameName))
            {
                throw new InvalidGameException("Game name cannot be empty");
            }

            if (minRange >= maxRange)
            {
                throw new InvalidGameException($"Minimum range ({minRange}) must be less than maximum range ({maxRange})");
            }

            if (numbersCount <= 0)
            {
                throw new InvalidGameException($"Number count must be positive (got {numbersCount})");
            }

            int availableNumbers = maxRange - minRange + 1;
            if (numbersCount > availableNumbers)
            {
                throw new InvalidGameException(
                    $"Cannot generate {numbersCount} unique numbers from range {minRange}-{maxRange} (only {availableNumbers} available)");
            }
        }

        /// <summary>
        /// Generates random unique numbers for the lottery game
        /// Numbers are sorted in ascending order
        /// </summary>
        /// <exception cref="InvalidGameException">Thrown if generation fails</exception>
        public void GenerateNumbers()
        {
            results.Clear();
            Random random = new Random();
            int count = 0;

            // Safety counter to prevent infinite loops
            int maxAttempts = numberCount * 100;
            int attempts = 0;

            while (count < numberCount && attempts < maxAttempts)
            {
                int number = random.Next(minRange, maxRange + 1);

                if (!results.Contains(number))
                {
                    results.Add(number);
                    count++;
                }
                attempts++;
            }

            if (count < numberCount)
            {
                throw new InvalidGameException(
                    $"Failed to generate {numberCount} unique numbers after {maxAttempts} attempts");
            }

            results.Sort();
        }
    }


    #region Exeption
    /// <summary>
    /// Custom exception for invalid game parameters or operations
    /// </summary>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class InvalidGameException : Exception
    {
        /// <summary>
        /// Initializes a new instance of InvalidGameException
        /// </summary>
        /// <param name="message">Error message describing the exception</param>
        public InvalidGameException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of InvalidGameException with inner exception
        /// </summary>
        /// <param name="message">Error message describing the exception</param>
        /// <param name="innerException">The exception that caused this exception</param>
        public InvalidGameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    #endregion
}