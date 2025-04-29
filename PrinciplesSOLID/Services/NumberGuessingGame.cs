using PrinciplesSOLID.Interfaces;
using PrinciplesSOLID.Models;

namespace PrinciplesSOLID.Services
{
    /// <summary>
    /// The NumberGuessingGame class is an implementation of the logic of the "Guess the Number" game.
    /// Implements INumberGuessingGame. Implements SRP, as it is responsible only for the game logic.
    /// Depends on IGameSettingsProvider (Dependency Inversion)
    /// </summary>
    public class NumberGuessingGame : INumberGuessingGame
    {
        private readonly IGameSettingsProvider _settingsProvider;

        private readonly Random _random = new();

        private readonly int _minRange;
        private readonly int _maxRange;
        private int _attemptsLeft;

        private readonly int _secretNumber;

        /// <summary>
        /// Конструктор класса. Использует Dependency Injection для получения IGameSettingsProvider.
        /// </summary>
        /// <param name="settingsProvider"></param>
        public NumberGuessingGame(IGameSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            GameSettings settings = _settingsProvider.GetSettings();

            _minRange = settings.MinRange;
            _maxRange = settings.MaxRange;
            _attemptsLeft = settings.MaxAttempts;

            _secretNumber = _random.Next(_minRange, _maxRange + 1);
        }

        // Implementation of the Guess() method from the INumberGuessingGame interface.
        public bool Guess(int guess)
        {
            _attemptsLeft--;

            if (guess < _secretNumber)
            {
                Console.WriteLine("Too low!");
                return false;
            }
            else if (guess > _secretNumber)
            {
                Console.WriteLine("Too high!");
                return false;
            }
            else
            {
                Console.WriteLine("You guessed it!");
                return true;
            }
        }

        // Implementation of the HasAttemptsLeft() method from the INumberGuessingGame interface.
        public bool HasAttemptsLeft()
        {
            return _attemptsLeft > 0;
        }

        // Implementation of the DisplayRemainingAttempts() method from the INumberGuessingGame interface.
        public void DisplayRemainingAttempts()
        {
            Console.WriteLine($"Attempts remaining: {_attemptsLeft}");
        }
    }
}
