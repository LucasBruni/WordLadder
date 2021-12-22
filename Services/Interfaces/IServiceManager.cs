namespace Services.Interfaces
{
    /// <summary>
    /// Service Manager Interface.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Gets Word Service.
        /// </summary>
        IWordService WordService { get; }

        /// <summary>
        /// Gets Word Ladder Service.
        /// </summary>
        IWordLadderService WordLadderService { get; }
    }
}
