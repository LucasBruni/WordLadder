using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    /// <summary>
    /// Word Service.
    /// </summary>
    public class WordService : IWordService
    {
        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Repository Manager.
        /// </summary>
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordService"/> class.
        /// </summary>
        /// <param name="repositoryManager">Repository Manager.</param>
        /// <param name="mapper">Mapper.</param>
        public WordService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.LoadWordList();
        }

        /// <summary>
        /// Gets Word List.
        /// </summary>
        public IEnumerable<WordModel> Words { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<WordModel> GetWordListByLength(int length)
        {
            return this.Words.Where(w => w.Length.Equals(length));
        }

        /// <inheritdoc/>
        public void SaveResult(IEnumerable<WordModel> resultList, string outputFilePath = null)
        {
            var result = this.mapper.Map<List<Word>>(resultList);
            this.repositoryManager.WordRepository.SaveResult(result, outputFilePath);
        }

        /// <summary>
        /// Load Word List.
        /// </summary>
        private void LoadWordList()
        {
            this.Words = this.mapper.Map<List<WordModel>>(this.repositoryManager.WordRepository.GetWords());
        }
    }
}
