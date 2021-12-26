using Domain.Entities;
using Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            var result = this.repositoryContext.Words;
            var wordList = result.Distinct().Select(w => new Word(w.Value));

            return wordList;
        }

        /// <inheritdoc/>
        public IEnumerable<Word> GetWordsByLength(int length, CancellationToken cancellationToken = default)
        {
            var result = this.repositoryContext.Words;
            var wordList = result.Distinct().Where(w => w.Length.Equals(length)).Select(w => new Word(w.Value));

            return wordList;
        }

        /// <inheritdoc/>
        public void SaveResult(IEnumerable<Word> resultList, string outputFilePath = null)
        {
            this.repositoryContext.SaveOutputFile(resultList, outputFilePath);
        }
    }
}
