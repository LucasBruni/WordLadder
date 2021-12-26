﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Domain.Repositories.Interfaces
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
        /// Get Words by length.
        /// </summary>
        /// <param name="length">Word Length.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>List of words.</returns>
        public IEnumerable<Word> GetWordsByLength(int length, CancellationToken cancellationToken = default);

        /// <summary>
        /// Save the Result.
        /// </summary>
        /// <param name="resultList">resultList.</param>
        /// <param name="outputFilePath">Output File Path.</param>
        public void SaveResult(IEnumerable<Word> resultList, string outputFilePath = null);
    }
}
