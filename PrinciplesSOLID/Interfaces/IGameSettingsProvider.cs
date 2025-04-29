using PrinciplesSOLID.Models;

namespace PrinciplesSOLID.Interfaces
{
    /// <summary>
    /// The IGameSettingsProvider interface is an abstraction for getting game settings.
    /// Implements the Dependency Inversion principle, allowing classes to depend on abstractions (interfaces) instead of concrete implementations. 
    /// </summary>
    public interface IGameSettingsProvider
    {
        /// <summary>
        /// A method for getting game settings.
        /// </summary>
        /// <returns></returns>
        GameSettings GetSettings();
    }
}
