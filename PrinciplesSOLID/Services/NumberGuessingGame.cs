using PrinciplesSOLID.Interfaces;

namespace PrinciplesSOLID.Services
{
    /// <summary>
    /// The NumberGuessingGame class is an implementation of the logic of the "Guess the Number" game.
    /// </summary>
    public class NumberGuessingGame : INumberGuessingGame
    {
        private readonly IGameSettingsProvider _settingsProvider;

        private readonly Random _random = new();

        private int _attemptsLeft;
        public int AttemptsLeft => _attemptsLeft;


        private int _secretNumber;
        public int SecretNumber => _secretNumber;

        public NumberGuessingGame(IGameSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            StartNewGame();
        }


        public void StartNewGame()
        {
            var settings = _settingsProvider.GetSettings();
            _attemptsLeft = settings.MaxAttempts;
            _secretNumber = _random.Next(settings.MinRange, settings.MaxRange + 1);
        }

        public bool Guess(int guess)
        {
            _attemptsLeft--;
            return guess == _secretNumber;
        }

        public string GetResult(int guess)
        {
            if (guess < _secretNumber) return "Too low!";
            if (guess > _secretNumber) return "Too high!";
            return "You guessed it!";
        }
    }
}
