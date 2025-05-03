using PrinciplesSOLID.Interfaces;

namespace PrinciplesSOLID.Controllers
{
    /// <summary>
    /// The GameController class manages the flow of the Number Guessing Game.
    /// </summary>
    public class GameController
    {
        private readonly INumberGuessingGame _numberGuessingGame;
        private readonly IUserInterface _userInterface;

        public GameController(INumberGuessingGame numberGuessingGame, IUserInterface userInterface)
        {
            _numberGuessingGame = numberGuessingGame;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.ShowMessage("Welcome to Guess the Number!");

            while (_numberGuessingGame.AttemptsLeft > 0)
            {
                int guess = _userInterface.GetGuess();
                string result = _numberGuessingGame.GetResult(guess);

                _userInterface.ShowMessage(result);

                if (_numberGuessingGame.Guess(guess))
                {
                    _userInterface.ShowMessage("Congratulations! You won!");
                    break;
                }
            }

            if (_numberGuessingGame.AttemptsLeft == 0)
            {
                _userInterface.ShowMessage($"You ran out of attempts. The number was {_numberGuessingGame.SecretNumber}.");
            }

            if (_userInterface.AskToPlayAgain())
            {
                _numberGuessingGame.StartNewGame();
                Run();
            }
        }
    }
}
