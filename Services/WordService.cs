﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Persistence.Repositories.Interfaces;
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

        private readonly IValidator<WordModel> wordValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordService"/> class.
        /// </summary>
        /// <param name="repositoryManager">Repository Manager.</param>
        /// <param name="mapper">Mapper.</param>
        /// <param name="validator">The Word Validator.</param>
        public WordService(IRepositoryManager repositoryManager, IMapper mapper, IValidator<WordModel> validator)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.wordValidator = validator;
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

        /// <inheritdoc/>
        public void ValidateWordModel(WordModel wordModel)
        {
            this.wordValidator.Validate(wordModel);
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
