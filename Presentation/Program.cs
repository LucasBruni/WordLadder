using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;

namespace Presentation
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        /// <param name="serviceManager">serviceManager.</param>
        public Program(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">args.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task Main()
        {
            var myTimer = new Stopwatch();
            myTimer.Start();

            var service = ConfigureServices();

            Program program = service.GetService<Program>();

            program.StartLadder();

            DisposeServices(service);
            myTimer.Stop();
            Console.WriteLine(myTimer.ElapsedMilliseconds);
        }

        private void StartLadder()
        {
            bool isValid;
            WordModel firstWord, targetWord;

            do
            {
                this.Menu(out firstWord, out targetWord);

                isValid = this.Validate(firstWord, targetWord);
            }
            while (isValid == false);

            var availableWords = this.serviceManager.WordService.GetWordListByLength(firstWord.Length);

            Console.WriteLine($"Available Words Loaded");

            var finalResult = this.serviceManager.WordLadderService.FindWordLadder(firstWord, targetWord, availableWords);

            foreach (var word in finalResult)
            {
                Console.WriteLine(word.Value);
            }

            var outputFilePath = $"{firstWord.Value}_{targetWord.Value}.txt";

            this.serviceManager.WordService.SaveResult(finalResult, outputFilePath);
        }

        private void Menu(out WordModel firstWord, out WordModel targetWord)
        {
            Console.WriteLine(string.Format("Enter the first word: "));
            firstWord = new WordModel("some");
            // firstWord = new WordModel(Console.ReadLine().Trim());

            Console.WriteLine(string.Format("Enter the target Word: "));
            targetWord = new WordModel("cost");
            //targetWord = new WordModel(Console.ReadLine().Trim());

            Console.WriteLine(Environment.NewLine);
        }

        private bool Validate(WordModel firstWord, WordModel targetWord)
        {
            bool isValid = false;

            StringBuilder message = new StringBuilder();

            if (firstWord.IsValid == false || firstWord.Length <= 1)
            {
                message.AppendLine("Error: The first word is invalid. Word can only contain letters and need to have at least 2 letters.");
            }

            if (targetWord.IsValid == false || targetWord.Length <= 1)
            {
                message.AppendLine("Error: The target word is invalid.  Word can only contain letters and need to have at least 2 letters.");
            }

            if (firstWord.Value.Equals(targetWord.Value))
            {
                message.AppendLine("Error: The words need to be differents.");
            }

            if (firstWord.Length != targetWord.Length)
            {
                message.AppendLine("Error: The words need to have the same lenght.");
            }

            if (this.serviceManager.WordService.IsInList(firstWord) == false)
            {
                message.AppendLine("Error: The first word isn't in the list of available words.");
            }

            if (this.serviceManager.WordService.IsInList(targetWord) == false)
            {
                message.AppendLine("Error: The target word isn't in the list of available words.");
            }

            if (message.Length > 0)
            {
                Console.WriteLine(message.ToString());
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Configure services.
        /// </summary>
        /// <param name="services">Services.</param>
        private static IServiceProvider ConfigureServices()
        {
            var service = new ServiceCollection();

            return service.AddLogging(config => config.ClearProviders().AddConsole().SetMinimumLevel(LogLevel.Debug))
            .AddScoped<IServiceManager, ServiceManager>()
            .AddScoped<IWordLadderService, WordLadderService>()
            .AddScoped<IWordService, WordService>()
            .AddAutoMapper(typeof(WordMapping))
            .AddScoped<IWordRepository, WordRepository>()
            .AddScoped<IRepositoryManager, RepositoryManager>()
            .AddScoped<IRepositoryContext, RepositoryContext>()
            .AddScoped<Program>()
            .BuildServiceProvider();
        }

        /// <summary>
        /// Dispose Services.
        /// </summary>
        /// <param name="serviceProvider">serviceProvider.</param>
        private static void DisposeServices(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }

            if (serviceProvider is IDisposable sp)
            {
                sp.Dispose();
            }
        }
    }
}
