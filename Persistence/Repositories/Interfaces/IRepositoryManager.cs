namespace Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Repository Manager Interface.
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Gets Word Repository.
        /// </summary>
        IWordRepository WordRepository { get; }
    }
}
