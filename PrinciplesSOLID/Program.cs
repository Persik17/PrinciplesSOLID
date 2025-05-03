using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrinciplesSOLID.Controllers;
using PrinciplesSOLID.Interfaces;
using PrinciplesSOLID.Services;
using PrinciplesSOLID.Settings;

namespace PrinciplesSOLID
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddSingleton<IGameSettingsProvider, GameSettingsProvider>();
            builder.Services.AddSingleton<INumberGuessingGame, NumberGuessingGame>();
            builder.Services.AddSingleton<IUserInterface, ConsoleUserInterface>();
            builder.Services.AddSingleton<IValidateInput, NumberFormatValidator>();
            builder.Services.AddSingleton<GameController>();

            var host = builder.Build();

            var gameController = host.Services.GetRequiredService<GameController>();
            gameController.Run();
        }
    }
}