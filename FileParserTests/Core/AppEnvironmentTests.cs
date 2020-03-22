using System;
using FileParser.Business.Operations.CountWords;
using FileParser.Core;
using Liba.Logger.Interfaces;
using Moq;
using Xunit;

namespace FileParserTests.Core
{
    public class AppEnvironmentTests
    {
        #region Private Members

        private readonly AppEnvironment environment;

        #endregion

        public AppEnvironmentTests()
        {
            var mockLogger = new Mock<ILogger>();

            environment = new AppEnvironment(mockLogger.Object);
        }

        [Fact]
        public void Ctor()
        {
            // Assert
            Assert.IsNotType<ArgumentNullException>(environment);
        }

        [Theory]
        [InlineData("filePath1", "123")]
        [InlineData("1", "2")]
        [InlineData("a", "b")]
        public void Parse(params string[] args)
        {
            // Arrange
            var expectedValue = new CountWordsData
            {
                FilePath = args[0],
                SearchWord = args[1]
            };

            // Act
            var actualValue = (CountWordsData)environment.Parse(args);

            // Assert
            Assert.Equal(expectedValue.FilePath, actualValue.FilePath);
            Assert.Equal(expectedValue.SearchWord, actualValue.SearchWord);
        }
    }
}