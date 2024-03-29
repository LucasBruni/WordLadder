﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

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

            var startup = new Startup();
            var service = startup.ConfigureServices();

            var program = service.GetService<Program>();

            bool isValid;
            do
            {
                isValid = program.MainMenu();
            }
            while (isValid == false);

            DisposeServices(service);
            myTimer.Stop();
            Console.WriteLine(myTimer.ElapsedMilliseconds);
        }

        /// <summary>
        /// Main Menu.
        /// </summary>
        private bool MainMenu()
        {
            Console.WriteLine("What do you want to start?");
            Console.WriteLine("1) Word Ladder");
            Console.WriteLine("2) Exit");
            Console.WriteLine("Choose an option: ");

            // string option = Console.ReadLine();
            var option = "1";
            Console.WriteLine(Environment.NewLine);

            var isValid = false;
            switch (option)
            {
                case "1":
                    isValid = true;

                    WordLadder wordLadder = new WordLadder(this.serviceManager);
                    wordLadder.StartWordLadder();

                    break;
                case "2":
                    isValid = true;
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
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
