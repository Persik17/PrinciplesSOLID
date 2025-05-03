
namespace PrinciplesSOLID.Interfaces
{
    /// <summary>
    /// The INumberGuessingGame interface is an abstraction for the logic of the Guess the Number game.
    /// Implements the Interface Segregation Principle (ISP) - defines only the necessary methods.
    /// </summary>
    public interface INumberGuessingGame
    {
        /// <summary>
        /// A method for verifying a player's assumption. Returns true if the player guessed the number.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        bool Guess(int guess);

        /// <summary>
        /// Gets the remaining attempts.
        /// </summary>
        int AttemptsLeft { get; }

        /// <summary>
        /// Randomized number
        /// </summary>
        int SecretNumber { get; }

        /// <summary>
        /// Starts a new game with a new random secret number.
        /// </summary>
        void StartNewGame();

        /// <summary>
        /// Gets the result of the guess.
        /// </summary>
        /// <param name="guess">The player's guess.</param>
        /// <returns>A string describing the result.</returns>
        string GetResult(int guess);
    }
}
