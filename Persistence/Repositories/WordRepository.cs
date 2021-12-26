using Domain.Entities;
using Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace Persistence.Repositories
{
    /// <summary>
    /// Word Repository Class.
    /// </summary>
    public class WordRepository : IWordRepository
    {
        /// <summary>
        /// Repository Context.
        /// </summary>
        private readonly IRepositoryContext repositoryContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">Repository Context.</param>
        public WordRepository(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        /// <inheritdoc/>
        public IEnumerable<Word> GetWords(CancellationToken cancellationToken = default)
        {
            return this.repositoryContext.Words;
        }

        /// <inheritdoc/>
        public void SaveResult(IEnumerable<Word> resultList, string outputFilePath = null)
        {
            this.repositoryContext.SaveOutputFile(resultList, outputFilePath);
        }
    }
}
