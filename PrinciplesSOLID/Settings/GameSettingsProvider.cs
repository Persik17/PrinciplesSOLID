using Microsoft.Extensions.Configuration;
using PrinciplesSOLID.Interfaces;
using PrinciplesSOLID.Models;

namespace PrinciplesSOLID.Settings
{

    /// <summary>
    /// The AppSettingsProvider class is a specific implementation of IGameSettingsProvider,
    /// which gets the settings from the appsettings.json file.  Implements SRP, as it is responsible only for reading the settings.
    /// Also implements OCP, as we can add new implementations of the IGameSettingsProvider interface
    /// without changing the NumberGuessingGame
    /// </summary>
    public class GameSettingsProvider : IGameSettingsProvider
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor of the class. Uses Dependency Injection to get the IConfiguration.
        /// </summary>
        /// <param name="configuration"></param>
        public GameSettingsProvider(IConfiguration configuration) => _configuration = configuration;


        // Implementation of the getSettings() method from the IGameSettingsProvider interface.
        // Reads the settings from the "GameSettings" section in the appsettings.json file.
        // Uses the default value if the file is not found or the section is missing.
        public GameSettings GetSettings()
        {
            return _configuration.GetSection("GameSettings").Get<GameSettings>() ?? new GameSettings { MaxAttempts = 5, MinRange = 1, MaxRange = 100 };
        }
    }
}
