using Services.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// Word Service Interface.
    /// </summary>
    public interface IWordService
    {
        /// <summary>
        /// Gets Word List.
        /// </summary>
        public IEnumerable<WordModel> Words { get; }

        /// <summary>
        /// Get Word List By Length.
        /// </summary>
        /// <param name="length">Length.</param>
        /// <returns>List of Word Models.</returns>
        public IEnumerable<WordModel> GetWordListByLength(int length);

        /// <summary>
        /// Save Result.
        /// </summary>
        /// <param name="resultList">resultList.</param>
        /// <param name="outputFilePath">Output File Path.</param>
        public void SaveResult(IEnumerable<WordModel> resultList, string outputFilePath = null);
    }
}
