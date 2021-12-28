using Domain.Entities;
using Moq;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Persistence.Tests
{
    public class WordRepositoryTest
    {
        [Fact]
        public void GetWords_WhenWordListHaveItems_NotEmpty()
        {
            // Arrange
            var wordRepository = this.GetWordService();

            // Act
            var result = wordRepository.GetWords();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetWords_WhenWordListEmpty_Empty()
        {
            // Arrange
            var fakeRepositoryContext = new Mock<IRepositoryContext>();
            fakeRepositoryContext.SetupGet(w => w.Words)
                .Returns(new List<Word>() { });

            IWordRepository wordRepository = new WordRepository(fakeRepositoryContext.Object);

            // Act
            var result = wordRepository.GetWords();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SaveResult_WhenHaveAnswer_CreateTxtFileWithAnswer()
        {
            // Arrange
            var fakeRepositoryContext = new Mock<RepositoryContext>();

            var wordRepository = new WordRepository(fakeRepositoryContext.Object);

            string firstWord = "case";
            string targetWord = "cose";
            var listResult = new List<Word>() { new Word(firstWord), new Word(targetWord) };

            string outputFilePath = $"{firstWord}_{targetWord}.txt";

            // Act
            wordRepository.SaveResult(listResult, outputFilePath);
            string savedPath = $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\Results\\{outputFilePath}";
            var fileSavedSuccessfully = File.Exists(savedPath);

            // Assert
            Assert.True(fileSavedSuccessfully);
        }

        private IWordRepository GetWordService()
        {
            var fakeRepositoryContext = new Mock<IRepositoryContext>();
            fakeRepositoryContext.SetupGet(w => w.Words)
                .Returns(new List<Word>() { new Word("Test"), new Word("Test2") });

            IWordRepository wordRepository = new WordRepository(fakeRepositoryContext.Object);

            return wordRepository;
        }
    }
}
