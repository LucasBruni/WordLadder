using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Moq;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Persistence.Tests
{
    public class WordRepositoryTest
    {
        [Fact]
        public void GetWords_NotEmpty()
        {
            // Arrange
            var wordRepository = this.GetWordService();

            // Act
            var result = wordRepository.GetWords();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetWordsByLength_NotEmpty()
        {
            // Arrange
            var wordRepository = this.GetWordService();

            // Act
            var result = wordRepository.GetWordsByLength(4);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetWordsByLength_Empty()
        {
            // Arrange
            var wordRepository = this.GetWordService();

            // Act
            var result = wordRepository.GetWordsByLength(9);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SaveResult()
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
                .Returns(new List<IWord>() { new Word("Test"), new Word("Test2") });

            IWordRepository wordRepository = new WordRepository(fakeRepositoryContext.Object);

            return wordRepository;
        }
    }
}
