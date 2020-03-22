using FileParser.Validation;
using Xunit;

namespace FileParserTests.Validation
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("a", "b")]
        [InlineData("1", "2", "3")]
        public void IsArgumentsValid_Positive(params string[] args)
        {
            // Act
            var actualValue = Validator.IsArgumentsValid(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("1", "2", "a", "b")]
        public void IsArgumentsValid_Negative(params string[] args)
        {
            // Act
            var actualValue = Validator.IsArgumentsValid(args);

            // Assert
            Assert.False(actualValue);
        }
    }
}