using Services.Interfaces;
using Services.Models;
using System;

namespace Presentation
{
    /// <summary>
    /// Word Ladder Game class.
    /// </summary>
    public class WordLadder
    {
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordLadder"/> class.
        /// </summary>
        /// <param name="serviceManager">serviceManager.</param>
        public WordLadder(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Start Word Ladder.
        /// </summary>
        public void StartWordLadder()
        {
            var isValid = false;
            WordModel firstWord = new WordModel();
            WordModel targetWord = new WordModel();

            do
            {
                try
                {
                    this.Menu(out firstWord, out targetWord);

                    this.serviceManager.WordLadderService.Validate(firstWord, targetWord, this.serviceManager.WordService.Words);

                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Environment.NewLine);
                }
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
            // firstWord = new WordModel("some");
            firstWord = new WordModel(Console.ReadLine().Trim());

            this.serviceManager.WordService.ValidateWordModel(firstWord);

            Console.WriteLine(string.Format("Enter the target Word: "));
            // targetWord = new WordModel("cost");
            targetWord = new WordModel(Console.ReadLine().Trim());

            this.serviceManager.WordService.ValidateWordModel(targetWord);

            Console.WriteLine(Environment.NewLine);
        }
    }
}
