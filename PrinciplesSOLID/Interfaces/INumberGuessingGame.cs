
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
        /// A method for checking if the player has any attempts left.
        /// </summary>
        /// <returns></returns>
        bool HasAttemptsLeft();

        /// <summary>
        /// A method for displaying the remaining attempts.
        /// </summary>
        void DisplayRemainingAttempts();
    }
}
