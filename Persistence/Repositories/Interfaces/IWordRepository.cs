using Domain.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Word Repository Interface.
    /// </summary>
    public interface IWordRepository
    {
        /// <summary>
        /// Get Words.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>List of words.</returns>
        public IEnumerable<Word> GetWords(CancellationToken cancellationToken = default);

        /// <summary>
        /// Save the Result.
        /// </summary>
        /// <param name="resultList">resultList.</param>
        /// <param name="outputFilePath">Output File Path.</param>
        public void SaveResult(IEnumerable<Word> resultList, string outputFilePath = null);
    }
}
