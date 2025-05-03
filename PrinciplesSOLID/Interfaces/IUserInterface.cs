namespace PrinciplesSOLID.Interfaces
{
    /// <summary>
    /// Defines the contract for user interaction in a number guessing game.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Gets a numerical guess from the user.
        /// </summary>
        /// <returns>The user's guessed number.</returns>
        int GetGuess();

        /// <summary>
        /// Asks the user if they want to play the game again.
        /// </summary>
        /// <returns>True if the user wants to play again; otherwise, false.</returns>
        bool AskToPlayAgain();
    }
}
