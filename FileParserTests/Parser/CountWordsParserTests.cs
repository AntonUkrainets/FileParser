using FileParser.Business.Operations.CountWords;
using FileParser.Parser;
using Xunit;

namespace FileParserTests.Parser
{
    public class CountWordsParserTests
    {
        #region Private Members

        private readonly CountWordsParser countWordsParser;

        #endregion

        public CountWordsParserTests()
        {
            countWordsParser = new CountWordsParser();
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("a", "b")]
        [InlineData("-1", "c")]
        public void CanParse_Positive(params string[] args)
        {
            // Act
            var actualValue = countWordsParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("a", "b", "c")]
        public void CanParse_Negative(params string[] args)
        {
            // Act
            var actualValue = countWordsParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData("filePath1", "123")]
        [InlineData("1", "2")]
        [InlineData("a", "b")]
        public void Parse_CountWords(params string[] args)
        {
            // Arrange
            var expectedValue = new CountWordsData
            {
                FilePath = args[0],
                SearchWord = args[1]
            };

            // Act
            var actualValue = (CountWordsData)countWordsParser.Parse(args);

            // Assert
            Assert.Equal(expectedValue.FilePath, actualValue.FilePath);
            Assert.Equal(expectedValue.SearchWord, actualValue.SearchWord);
        }
    }
}