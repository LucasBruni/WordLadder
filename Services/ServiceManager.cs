using Services.Interfaces;

namespace Services
{
    /// <summary>
    /// Word Service.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        /// <param name="wordService">wordService.</param>
        /// <param name="wordLadderService">wordLadderService.</param>
        public ServiceManager(IWordService wordService, IWordLadderService wordLadderService)
        {
            this.WordLadderService = wordLadderService;
            this.WordService = wordService;
        }

        /// <inheritdoc/>
        public IWordService WordService { get; }

        /// <inheritdoc/>
        public IWordLadderService WordLadderService { get; }
    }
}
