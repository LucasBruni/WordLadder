using System.Collections.Generic;
using Domain.Entities.Interfaces;

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
        public IEnumerable<IWord> Words { get; set; }

        /// <summary>
        /// Save the result at the output file.
        /// </summary>
        /// <param name="resultList">Result List.</param>
        /// <param name="outputFilePath">Output File Path.</param>
        public void SaveOutputFile(IEnumerable<IWord> resultList, string outputFilePath = null);
    }
}
