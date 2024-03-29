﻿using Services.Exceptions;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Services.Tests
{
    public class WordLadderServiceTest
    {
        [Fact]
        public void FindWordLadder_WithoutMatch()
        {
            // Arrange
            IWordLadderService wordLadderService = this.GetWordLadderService();
            var firstWord = new WordModel("same");
            var targetWord = new WordModel("come");
            var availableWords = new List<WordModel>() { firstWord, targetWord };

            // Act
            var result = wordLadderService.FindWordLadder(firstWord, targetWord, availableWords);

            // Assert
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("same", "came")]
        [InlineData("same", "cost")]
        public void FindWordLadder_WithMatch(string firstWord, string targetWord)
        {
            // Arrange
            IWordLadderService wordLadderService = this.GetWordLadderService();
            var firstWordModel = new WordModel(firstWord);
            var targetWordModel = new WordModel(targetWord);
            var availableWords = new List<WordModel>() {
                firstWordModel,
                new WordModel("came"),
                new WordModel("case"),
                new WordModel("cast"),
                targetWordModel,
            };

            // Act
            var result = wordLadderService.FindWordLadder(firstWordModel, targetWordModel, availableWords);

            // Assert
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("same", "same")]
        public void Validate_WithSameWord_ThrowSameWordsException(string firstWord, string targetWord)
        {
            // Arrange
            IWordLadderService wordLadderService = this.GetWordLadderService();
            var firstWordModel = new WordModel(firstWord);
            var targetWordModel = new WordModel(targetWord);
            var availableWords = new List<WordModel>() {
                firstWordModel,
                new WordModel("came"),
                new WordModel("case"),
                new WordModel("cast"),
                targetWordModel,
            };

            // Act
            Action test = () => wordLadderService.Validate(firstWordModel, targetWordModel, availableWords);

            // Asset
            Assert.ThrowsAny<SameWordsException>(test);
        }

        [Theory]
        [InlineData("same", "castle")]
        public void Validate_WithDifferentLength_ThrowDifferentWordLengthException(string firstWord, string targetWord)
        {
            // Arrange
            IWordLadderService wordLadderService = this.GetWordLadderService();
            var firstWordModel = new WordModel(firstWord);
            var targetWordModel = new WordModel(targetWord);
            var availableWords = new List<WordModel>() {
                firstWordModel,
                new WordModel("came"),
                new WordModel("case"),
                new WordModel("cast"),
                targetWordModel,
            };

            // Act
            Action test = () => wordLadderService.Validate(firstWordModel, targetWordModel, availableWords);

            // Asset
            Assert.ThrowsAny<DifferentWordLengthException>(test);
        }

        [Theory]
        [InlineData("ak", "ye")]
        public void Validate_WhenWordNotInList_ThrowWordNotAvailableInListException(string firstWord, string targetWord)
        {
            // Arrange
            IWordLadderService wordLadderService = this.GetWordLadderService();
            var firstWordModel = new WordModel(firstWord);
            var targetWordModel = new WordModel(targetWord);
            var availableWords = new List<WordModel>() {
                new WordModel("came"),
                new WordModel("case"),
                new WordModel("cast"),
            };

            // Act
            Action test = () => wordLadderService.Validate(firstWordModel, targetWordModel, availableWords);

            // Asset
            Assert.ThrowsAny<WordNotAvailableInListException>(test);
        }

        private IWordLadderService GetWordLadderService()
        {
            IWordLadderService wordLadderService = new WordLadderService();

            return wordLadderService;
        }
    }
}
