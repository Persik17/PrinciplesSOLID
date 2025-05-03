namespace PrinciplesSOLID.Interfaces
{
    /// <summary>
    /// Validator for ensuring input is a valid integer number.
    /// </summary>
    public interface IValidateInput
    {
        /// <summary>
        /// Validates that the input string can be parsed as an integer.
        /// </summary>
        /// <param name="input">The string input to validate.</param>
        void Validate(string input);
    }
}
