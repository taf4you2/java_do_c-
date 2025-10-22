using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoGameApp.Model
{
    /// <summary>
    /// Represents a lotto-style game with configurable parameters.
    /// </summary>
    /// <remarks>
    /// This class manages the game configuration and number generation logic.
    /// Numbers are generated randomly without repetition and sorted in ascending order.
    /// </remarks>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public class Game
    {
        #region Private Fields

        /// <summary>
        /// The name of the game.
        /// </summary>
        private readonly string _gameName;

        /// <summary>
        /// The count of numbers to generate.
        /// </summary>
        private readonly int _numberCount;

        /// <summary>
        /// The minimum value in the number range (inclusive).
        /// </summary>
        private readonly int _minRange;

        /// <summary>
        /// The maximum value in the number range (inclusive).
        /// </summary>
        private readonly int _maxRange;

        /// <summary>
        /// List containing the generated numbers.
        /// </summary>
        private readonly List<int> _generatedNumbers;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the name of the game.
        /// </summary>
        /// <value>The game name as a string.</value>
        public string GameName => _gameName;

        /// <summary>
        /// Gets the count of numbers to be generated.
        /// </summary>
        /// <value>The number count as an integer.</value>
        public int NumberCount => _numberCount;

        /// <summary>
        /// Gets the minimum value in the number range.
        /// </summary>
        /// <value>The minimum range value as an integer.</value>
        public int MinRange => _minRange;

        /// <summary>
        /// Gets the maximum value in the number range.
        /// </summary>
        /// <value>The maximum range value as an integer.</value>
        public int MaxRange => _maxRange;

        /// <summary>
        /// Gets the list of generated numbers.
        /// </summary>
        /// <value>A read-only collection of generated integers.</value>
        public IReadOnlyList<int> GeneratedNumbers => _generatedNumbers.AsReadOnly();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Game class with specified parameters.
        /// </summary>
        /// <param name="gameName">The name of the game.</param>
        /// <param name="numberCount">The count of numbers to generate.</param>
        /// <param name="minRange">The minimum value in the number range (inclusive).</param>
        /// <param name="maxRange">The maximum value in the number range (inclusive).</param>
        /// <exception cref="InvalidGameConfigurationException">
        /// Thrown when game parameters are invalid:
        /// - numberCount is less than or equal to 0
        /// - minRange is greater than or equal to maxRange
        /// - numberCount exceeds the available range
        /// - gameName is null or empty
        /// </exception>
        public Game(string gameName, int numberCount, int minRange, int maxRange)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(gameName))
            {
                throw new InvalidGameConfigurationException("Game name cannot be null or empty.");
            }

            if (numberCount <= 0)
            {
                throw new InvalidGameConfigurationException(
                    $"Number count must be greater than 0. Provided: {numberCount}");
            }

            if (minRange >= maxRange)
            {
                throw new InvalidGameConfigurationException(
                    $"Minimum range ({minRange}) must be less than maximum range ({maxRange}).");
            }

            int availableNumbers = maxRange - minRange + 1;
            if (numberCount > availableNumbers)
            {
                throw new InvalidGameConfigurationException(
                    $"Cannot generate {numberCount} unique numbers from range {minRange}-{maxRange} " +
                    $"(only {availableNumbers} numbers available).");
            }

            _gameName = gameName;
            _numberCount = numberCount;
            _minRange = minRange;
            _maxRange = maxRange;
            _generatedNumbers = new List<int>(numberCount);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates random unique numbers within the configured range.
        /// </summary>
        /// <remarks>
        /// This method generates the specified count of unique random numbers
        /// within the range [minRange, maxRange], then sorts them in ascending order.
        /// Previous results are cleared before generating new numbers.
        /// </remarks>
        public void GenerateNumbers()
        {
            _generatedNumbers.Clear();
            Random random = new Random();

            while (_generatedNumbers.Count < _numberCount)
            {
                int number = random.Next(_minRange, _maxRange + 1);

                if (!_generatedNumbers.Contains(number))
                {
                    _generatedNumbers.Add(number);
                }
            }

            _generatedNumbers.Sort();
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Returns a string representation of the game.
        /// </summary>
        /// <returns>A string containing the game name and configuration details.</returns>
        public override string ToString()
        {
            return $"{_gameName} ({_numberCount} numbers from {_minRange} to {_maxRange})";
        }

        #endregion
    }
}