using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories
{
    /// <summary>
    /// Repository Manager Class.
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="wordRepository">ord Repository.</param>
        public RepositoryManager(IWordRepository wordRepository)
        {
            this.WordRepository = wordRepository;
        }

        /// <inheritdoc/>
        public IWordRepository WordRepository { get; }
    }
}
