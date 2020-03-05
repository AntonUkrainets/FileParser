using FileParser;
using FileParser.Files;
using FileParser.OperationHandlers;
using Moq;
using System;
using Xunit;

namespace FileParserTests
{
    public class ReplaceWordHandlerTests
    {
        [Fact]
        public void CanProcess_Positive()
        {
            // Arrange
            var inputData = new InputData
            {
                Operation = Operation.Replace
            };

            var fileManagerMock = new Mock<IFileManager>();

            var handler = new ReplaceWordHandler(fileManagerMock.Object);

            // Act
            var actualValue = handler.CanProcess(inputData.Operation);

            // Assert
            Assert.True(actualValue);
        }

        [Fact]
        public void CanProcess_Negative()
        {
            // Arrange
            var inputData = new InputData
            {
                Operation = Operation.Count
            };

            var fileManagerMock = new Mock<IFileManager>();

            var handler = new ReplaceWordHandler(fileManagerMock.Object);

            // Act
            var actualValue = handler.CanProcess(inputData.Operation);

            // Assert
            Assert.False(actualValue);
        }

        [Fact]
        public void CantProcess_Positive()
        {
            // Arrange
            var inputData = new InputData
            {
                Operation = Operation.Count
            };

            // Act
            var actualValue = Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var handler = new ReplaceWordHandler(null);
                    }
            );

            // Assert
            Assert.IsType<ArgumentNullException>(actualValue);
        }

        [Fact]
        public void CantProcess_Negative()
        {
            // Arrange
            var inputData = new InputData
            {
                Operation = Operation.Replace
            };

            // Act
            var actualValue = Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var handler = new ReplaceWordHandler(null);
                    }
            );

            // Assert
            Assert.IsType<ArgumentNullException>(actualValue);
        }
    }
}