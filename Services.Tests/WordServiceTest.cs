using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Moq;
using Persistence;
using Persistence.Repositories;
using Services.Exceptions;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;
using Services.Validators;
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

        [Fact]
        public void SaveResult_WithAnswer_CreateTxtFile()
        {
            // Arrange
            var fakeRepositoryContext = new Mock<RepositoryContext>();
            var fakeWordRepository = new Mock<WordRepository>(fakeRepositoryContext.Object);
            var fakeRepositoryManager = new Mock<RepositoryManager>(fakeWordRepository.Object);
            var fakeValidator = new Mock<IValidator<WordModel>>();
            IWordService wordService = new WordService(fakeRepositoryManager.Object, this.Mapper, fakeValidator.Object);
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

        [Fact]
        public void Words_WithData_NotEmpty()
        {
            // Arrange
            IWordService wordService = this.GetWordService();

            // Act
            var words = wordService.Words;

            // Asset
            Assert.NotEmpty(words);
        }

        [Theory]
        [InlineData("")]
        [InlineData("T")]
        [InlineData("Test.")]
        public void ValidateWordModel_WithInvalidWordModel_ThrowInvalidWordValueException(string word)
        {
            // Arrange
            IWordService wordService = this.GetWordService();
            WordModel wordModel = new WordModel(word);

            // Act
            Action test = () => wordService.ValidateWordModel(wordModel);

            // Asset
            Assert.ThrowsAny<InvalidWordValueException>(test);
        }

        [Theory]
        [InlineData("same")]
        [InlineData("cost")]
        public void ValidateWordModel_WithValidWordModel_ThrowInvalidWordValueException(string word)
        {
            // Arrange
            IWordService wordService = this.GetWordService();
            WordModel wordModel = new WordModel(word);

            // Act
            wordService.ValidateWordModel(wordModel);

            // Asset
            Assert.True(true);
        }

        private IWordService GetWordService()
        {
            var fakeWordRepository = new Mock<IWordRepository>();
            fakeWordRepository.Setup(w => w.GetWords(default))
                .Returns(new List<Word>() { new Word("Test"), new Word("Test2") });

            var fakeRepositoryManager = new Mock<RepositoryManager>(fakeWordRepository.Object);

            var validator = new WordModelValidator();

            IWordService wordService = new WordService(fakeRepositoryManager.Object, this.Mapper, validator);

            return wordService;
        }
    }
}
