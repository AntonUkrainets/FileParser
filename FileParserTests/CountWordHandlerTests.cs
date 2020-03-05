using FileParser;
using FileParser.Files;
using FileParser.Logger.Interfaces;
using FileParser.OperationHandlers;
using Moq;
using System;
using Xunit;

namespace FileParserTests
{
    public class CountWordHandlerTests
    {
        [Fact]
        public void CanProcess_Positive()
        {
            // Arrange
            var expectedValue = true;
            var inputData = new InputData
            {
                Operation = Operation.Count
            };

            var fileManagerMock = new Mock<IFileManager>();
            var loggerMock = new Mock<ILogger>();

            var handler = new CountWordHandler(
                fileManagerMock.Object,
                loggerMock.Object
            );

            // Act
            var actualValue = handler.CanProcess(inputData.Operation);

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
                Operation = Operation.Replace
            };

            var fileManagerMock = new Mock<IFileManager>();
            var loggerMock = new Mock<ILogger>();

            var handler = new CountWordHandler(
                fileManagerMock.Object,
                loggerMock.Object
            );

            // Act
            var actualValue = handler.CanProcess(inputData.Operation);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CantProcess_Positive()
        {
            // Arrange
            var inputData = new InputData
            {
                Operation = Operation.Count
            };

            // Assert
            var actualValue = Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var handler = new CountWordHandler(null, null);
                    }
            );

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

            // Assert
            var actualValue = Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var handler = new CountWordHandler(null, null);
                    }
            );

            Assert.IsType<ArgumentNullException>(actualValue);
        }

        [Fact]
        public void Process()
        {
            // Arrange
            var text = "123 456 789 456";
            var searchWord = "456";

            var expectedMessage = "Count founded words: 2";

            var inputData = new InputData
            {
                Operation = Operation.Replace,
                SearchWord = searchWord
            };

            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(x => x.ReadText(It.IsAny<string>()))
                .Returns(text);

            var actualMessage = string.Empty;

            var loggerMock = new Mock<ILogger>();
            loggerMock
                .Setup(x => x.LogInformation(It.IsAny<string>()))
                .Callback<string>(message => actualMessage = message);

            var handler = new CountWordHandler(
                fileManagerMock.Object,
                loggerMock.Object
            );

            // Act
            handler.Process(inputData);

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}