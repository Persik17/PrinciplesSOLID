using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrinciplesSOLID.Interfaces;
using PrinciplesSOLID.Services;
using PrinciplesSOLID.Settings;

namespace PrinciplesSOLID
{
    //Краткое резюме по принципам SOLID в этой реализации:
    //SRP(Single Responsibility Principle): Каждый класс имеет одну четкую ответственность (например, AppSettingsProvider отвечает только за чтение настроек, NumberGuessingGame - за игровую логику).
    //OCP (Open/Closed Principle): Можно добавлять новые источники настроек (например, из базы данных), реализуя интерфейс IGameSettingsProvider, не изменяя класс NumberGuessingGame.
    //LSP (Liskov Substitution Principle): AppSettingsProvider(или любая другая реализация IGameSettingsProvider) может быть использован вместо базового типа IGameSettingsProvider без нарушения работы приложения.
    //ISP (Interface Segregation Principle): Интерфейсы(например, IGameSettingsProvider, INumberGuessingGame) разделены, чтобы классы зависели только от методов, которые им необходимы.
    //DIP (Dependency Inversion Principle): Классы верхнего уровня (например, NumberGuessingGame) зависят от абстракций (интерфейсов), а не от конкретных реализаций. Зависимости внедряются с использованием DI.

    public class Program
    {
        private static void Main(string[] args)
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton<IGameSettingsProvider, AppSettingsProvider>()
                .AddSingleton<INumberGuessingGame, NumberGuessingGame>()
                .BuildServiceProvider();

            // Getting services from a DI container.
            var settingsProvider = serviceProvider.GetService<IGameSettingsProvider>();
            var game = serviceProvider.GetService<INumberGuessingGame>();

            // Start the game
            Console.WriteLine("Welcome to Guess the Number!");
            Console.WriteLine($"I'm thinking of a number between {settingsProvider.GetSettings().MinRange} and {settingsProvider.GetSettings().MaxRange}.");
            game.DisplayRemainingAttempts();

            while (game.HasAttemptsLeft())
            {
                Console.Write("Take a guess: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (game.Guess(guess))
                    {
                        Console.WriteLine("Congratulations! You guessed the number!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (game.HasAttemptsLeft())
                {
                    game.DisplayRemainingAttempts();
                }
                else
                {
                    Console.WriteLine("You ran out of attempts. Better luck next time!");
                }
            }

            Console.ReadLine();
        }
    }
}