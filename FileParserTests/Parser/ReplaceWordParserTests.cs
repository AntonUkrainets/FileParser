using FileParser.Business.Operations.ReplaceWord;
using FileParser.Parser;
using Xunit;

namespace FileParserTests.Parser
{
    public class ReplaceWordParserTests
    {
        #region Private Members

        private readonly ReplaceWordParser replaceWordParser;

        #endregion

        public ReplaceWordParserTests()
        {
            replaceWordParser = new ReplaceWordParser();
        }

        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("a", "b", "c")]
        [InlineData("-1", "c", "&")]
        public void CanParse_Positive(params string[] args)
        {
            // Act
            var actualValue = replaceWordParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1", "2")]
        [InlineData("a", "b", "c", "d")]
        public void CanParse_Negative(params string[] args)
        {
            // Act
            var actualValue = replaceWordParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData("filePath1", "123", "456")]
        [InlineData("1", "2", "3")]
        [InlineData("a", "b", "c")]
        public void Parse_CountWords(params string[] args)
        {
            // Arrange
            var expectedValue = new ReplaceWordData
            {
                FilePath = args[0],
                SearchWord = args[1],
                ReplaceableWord = args[2]
            };

            // Act
            var actualValue = (ReplaceWordData)replaceWordParser.Parse(args);

            // Assert
            Assert.Equal(expectedValue.FilePath, actualValue.FilePath);
            Assert.Equal(expectedValue.SearchWord, actualValue.SearchWord);
            Assert.Equal(expectedValue.ReplaceableWord, actualValue.ReplaceableWord);
        }
    }
}