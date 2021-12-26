using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories.Interfaces
{
    /// <summary>
    /// Repository Manager Interface.
    /// </summary>
    public interface IRepositoryContext
    {
        /// <summary>
        /// Gets or sets Word List.
        /// </summary>
        public IEnumerable<Word> Words { get; set; }

        /// <summary>
        /// Save the result at the output file.
        /// </summary>
        /// <param name="resultList">Result List.</param>
        /// <param name="outputFilePath">Output File Path.</param>
        public void SaveOutputFile(IEnumerable<Word> resultList, string outputFilePath = null);
    }
}
