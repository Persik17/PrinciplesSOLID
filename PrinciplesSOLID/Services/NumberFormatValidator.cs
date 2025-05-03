using PrinciplesSOLID.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PrinciplesSOLID.Services
{
    /// <summary>
    /// Validator for ensuring input is a valid integer number.
    /// </summary>
    public class NumberFormatValidator : IValidateInput
    {
        public NumberFormatValidator() { }

        public void Validate(string input)
        {
            if (!int.TryParse(input, out _))
            {
                throw new ValidationException("Invalid input. Please enter a valid number.");
            }
        }
    }
}
