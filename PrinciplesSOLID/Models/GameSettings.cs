namespace PrinciplesSOLID.Models
{
    /// <summary>
    /// The GameSettings class is a data model for game settings.
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// A property for the maximum number of attempts.
        /// </summary>
        public int MaxAttempts { get; set; }

        /// <summary>
        /// A property for the minimum value in a range of numbers.
        /// </summary>
        public int MinRange { get; set; }

        /// <summary>
        /// A property for the maximum value in a range of numbers.
        /// </summary>
        public int MaxRange { get; set; }
    }
}
