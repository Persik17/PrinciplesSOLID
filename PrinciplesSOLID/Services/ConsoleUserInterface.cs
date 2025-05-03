using PrinciplesSOLID.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PrinciplesSOLID.Services
{
    /// <summary>
    /// The ConsoleUserInterface class implements the IUserInterface interface, providing a console-based user interface for the Number Guessing Game.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        private readonly IValidateInput _formatValidator;

        public ConsoleUserInterface(IValidateInput formatValidator)
        {
            _formatValidator = formatValidator;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int GetGuess()
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            try
            {
                _formatValidator.Validate(input);
                return int.Parse(input);
            }
            catch (ValidationException)
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
