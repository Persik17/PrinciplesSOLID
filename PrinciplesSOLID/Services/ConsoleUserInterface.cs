using PrinciplesSOLID.Interfaces;

namespace PrinciplesSOLID.Services
{
    /// <summary>
    /// The ConsoleUserInterface class implements the IUserInterface interface, providing a console-based user interface for the Number Guessing Game.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        public ConsoleUserInterface() { }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int GetGuess()
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int guess))
            {
                return guess;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return GetGuess();
            }
        }

        public bool AskToPlayAgain()
        {
            Console.Write("Do you want to play again? (y/n): ");
            return Console.ReadLine().ToLower() == "y";
        }
    }
}
