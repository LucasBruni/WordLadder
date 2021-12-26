using System.Collections.Generic;
using Xunit;

namespace Core.Tests
{
    /// <summary>
    /// Extension Methods Test Class.
    /// </summary>
    public class ExtensionMethodsTest
    {
        [Fact]
        public void IsInList_WhenThereIs_ReturnTrue()
        {
            // Arrange
            var myList = new List<string>() { "1", "2", "3" };

            // Act
            var result = myList.IsInList("2");

            // Asset
            Assert.True(result);
        }

        [Fact]
        public void IsInList_WhenThereIsNot_ReturnFalse()
        {
            // Arrange
            var myList = new List<string>() { "1", "2", "3" };

            // Act
            var result = myList.IsInList("5");

            // Asset
            Assert.False(result);
        }
    }
}
