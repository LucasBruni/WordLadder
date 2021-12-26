using Domain.Entities;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence
{
    /// <summary>
    /// Repository Context.
    /// </summary>
    public class RepositoryContext : IRepositoryContext
    {
        private readonly string inputFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="inputFilePath">inputFilePath.</param>
        public RepositoryContext()
        {
            // this.inputFilePath = ConfigurationManager.AppSettings.Get("InputFilePath");
            this.inputFilePath = $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\words-english.txt";
            this.LoadWords();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="inputFilePath">inputFilePath.</param>
        public RepositoryContext(string inputFilePath)
        {
            this.inputFilePath = inputFilePath ?? AppDomain.CurrentDomain.BaseDirectory;
            this.LoadWords();
        }

        /// <inheritdoc/>
        public IEnumerable<Word> Words { get; set; }

        /// <inheritdoc/>
        public void SaveOutputFile(IEnumerable<Word> resultList, string outputFilePath = null)
        {
            try
            {
                var pathToSave = this.inputFilePath.Replace("words-english.txt", $"Results\\{outputFilePath}");
                var file = new FileInfo(pathToSave);
                file.Directory.Create();
                File.WriteAllLinesAsync(pathToSave, resultList.Select(w => w.Value).ToList());

                Console.WriteLine($"Results saved at: {pathToSave}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving the result list on: {outputFilePath}. Error message: {ex.Message} \nInner message: {ex.InnerException}");
            }
        }

        /// <summary>
        /// Get the list of words.
        /// </summary>
        private async void LoadWords()
        {
            try
            {
                var result = await File.ReadAllLinesAsync(this.inputFilePath);
                this.Words = result.Select(w => new Word(w.Trim().ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the file. \nError message: {ex.Message} \nInner message: {ex.InnerException}");
            }
        }
    }
}
