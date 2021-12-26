using Domain.Entities;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Persistence.Tests
{
    public class RepositoryContextTest
    {
        [Fact]
        public void SaveOutputFile_WhenHaveAnswer_CreateTxtFileWithAnswer()
        {
            // Arrange
            var repositoryContext = this.GetRepositoryContext();
            string firstWord = "same";
            string targetWord = "some";
            var listResult = new List<Word>() { new Word(firstWord), new Word(targetWord) };
            string outputFilePath = $"{firstWord}_{targetWord}.txt";

            // Act
            repositoryContext.SaveOutputFile(listResult, outputFilePath);
            string savedPath = $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\Results\\{outputFilePath}";
            var fileSavedSuccessfully = File.Exists(savedPath);

            // Assert
            Assert.True(fileSavedSuccessfully);
        }

        private IRepositoryContext GetRepositoryContext()
        {
            IRepositoryContext wordRepository = new RepositoryContext();

            return wordRepository;
        }
    }
}
