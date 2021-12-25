using AutoMapper;
using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Moq;
using Persistence;
using Persistence.Repositories;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Services.Tests
{
    /// <summary>
    /// Word Service Test class.
    /// </summary>
    public class WordServiceTest
    {
        /// <summary>
        /// Gets or sets automapper instance.
        /// </summary>
        public IMapper Mapper { get; set; } = null!;

        public WordServiceTest()
        {
            // Initialize AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddMaps(new[]
            {
                typeof(WordMapping),
            }));
            config.AssertConfigurationIsValid();
            this.Mapper = config.CreateMapper();
        }

        /// <summary>
        /// Test the GetWordListByLength with Empty List.
        /// </summary>
        [Fact]
        public void GetWordListByLength_EmptyList()
        {
            // Arrange
            IWordService wordService = this.GetWordService();

            // Act
            var list = wordService.GetWordListByLength(9);

            // Assert
            Assert.Empty(list);
        }

        /// <summary>
        /// Test the GetWordListByLength with List not Empty.
        /// </summary>
        [Fact]
        public void GetWordListByLength_NotEmpty()
        {
            // Arrange
            IWordService wordService = this.GetWordService();

            // Act
            var list = wordService.GetWordListByLength(4);

            // Assert
            Assert.NotEmpty(list);
        }

        /// <summary>
        /// Test the GetWordList with List not Empty.
        /// </summary>
        [Fact]
        public void SaveResult()
        {
            // Arrange
            var fakeRepositoryContext = new Mock<RepositoryContext>();
            var fakeWordRepository = new Mock<WordRepository>(fakeRepositoryContext.Object);
            var fakeRepositoryManager = new Mock<RepositoryManager>(fakeWordRepository.Object);
            IWordService wordService = new WordService(fakeRepositoryManager.Object, this.Mapper);
            string firstWord = "cast";
            string targetWord = "cost";
            var listResult = new List<WordModel>() { new WordModel(firstWord), new WordModel(targetWord) };

            string outputFilePath = $"{firstWord}_{targetWord}.txt";

            // Act
            wordService.SaveResult(listResult, outputFilePath);
            string savedPath = $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\Results\\{outputFilePath}";
            var fileSavedSuccessfully = File.Exists(savedPath);

            // Assert
            Assert.True(fileSavedSuccessfully);
        }

        private IWordService GetWordService()
        {
            var fakeWordRepository = new Mock<IWordRepository>();
            fakeWordRepository.Setup(w => w.GetWords(default))
                .Returns(new List<IWord>() { new Word("Test"), new Word("Test2") });

            var fakeRepositoryManager = new Mock<RepositoryManager>(fakeWordRepository.Object);

            IWordService wordService = new WordService(fakeRepositoryManager.Object, this.Mapper);

            return wordService;
        }
    }
}
