using FileParser;
using FileParser.Files;
using FileParser.OperationHandlers;
using Moq;
using Xunit;

namespace FileParserTests
{
    public class ReplaceWordHandlerTests
    {
        [Fact]
        public void CanProcess_Positive()
        {
            // Arrange
            var expectedValue = true;
            var inputData = new InputData
            {
                Operation = Operation.Replace
            };

            var fileManagerMock = new Mock<IFileManager>();

            var handler = new ReplaceWordHandler(fileManagerMock.Object);

            // Act
            var actualValue = handler.CanProcess(inputData);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CanProcess_Negative()
        {
            // Arrange
            var expectedValue = false;
            var inputData = new InputData
            {
                Operation = Operation.Count
            };

            var fileManagerMock = new Mock<IFileManager>();

            var handler = new ReplaceWordHandler(fileManagerMock.Object);

            // Act
            var actualValue = handler.CanProcess(inputData);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}