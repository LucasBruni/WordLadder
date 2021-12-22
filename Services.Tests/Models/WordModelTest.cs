using Services.Models;
using Xunit;

namespace Services.Tests.Models
{
    public class WordModelTest
    {
        [Fact]
        public void WordModel_IsValid()
        {
            // Arrange
            var wordModel = new WordModel("Test");

            // Act
            var result = wordModel.IsValid;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void WordModel_IsNotValid()
        {
            // Arrange
            var wordModel = new WordModel("/Test./");

            // Act
            var result = wordModel.IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void WordModel_Length_Correct()
        {
            // Arrange
            var wordModel = new WordModel("Test");

            // Act
            var result = wordModel.Length;

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void WordModel_IsLike()
        {
            // Arrange
            var word1 = new WordModel("cast");
            var word2 = new WordModel("cost");

            // Act
            var result = word1.IsLike(word2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void WordModel_IsNotLike()
        {
            // Arrange
            var word1 = new WordModel("cast");
            var word2 = new WordModel("same");

            // Act
            var result = word1.IsLike(word2);

            // Assert
            Assert.False(result);
        }
    }
}
