using System;
using FileParser.Business.Operations.CountWords;
using FileParser.Business.Operations.ReplaceWord;
using FileParser.FilesManagers.Interfaces;
using Liba.Logger.Interfaces;
using Moq;
using Xunit;

namespace FileParserTests.Business.Operations.ReplaceWord
{
    public class ReplaceWordOperationTests
    {
        #region Private Members

        private readonly ReplaceWordOperation replaceWordOperation;

        #endregion

        public ReplaceWordOperationTests()
        {
            var mockFileManager = new Mock<IFileManager>();
            var mockLogger = new Mock<ILogger>();

            replaceWordOperation = new ReplaceWordOperation(
                mockFileManager.Object,
                mockLogger.Object
            );
        }

        [Fact]
        public void Ctor()
        {
            // Assert
            Assert.IsNotType<ArgumentNullException>(replaceWordOperation);
        }

        [Fact]
        public void CanProcess_Positive()
        {
            // Arrange
            var replaceWordData = new ReplaceWordData();

            // Actual
            var actualValue = replaceWordOperation.CanProcess(replaceWordData);

            // Assert
            Assert.True(actualValue);
        }

        [Fact]
        public void CanProcess_Negative()
        {
            // Arrange
            var countWordsData = new CountWordsData();

            // Actual
            var actualValue = replaceWordOperation.CanProcess(countWordsData);

            // Assert
            Assert.False(actualValue);
        }

        [Fact]
        public void Process()
        {
            // Arrange
            var text = "123 456 123 456 789 123";
            var filePath = "File.txt";

            var replaceWordData = new ReplaceWordData
            {
                FilePath = filePath,
                SearchWord = "123",
                ReplaceableWord = "abc"
            };

            var expectedMessage = $"The word {replaceWordData.SearchWord} was changed on {replaceWordData.ReplaceableWord}";

            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(m => m.ReadText(filePath))
                .Returns(text);

            var actualMessage = string.Empty;

            var loggerMock = new Mock<ILogger>();
            loggerMock
                .Setup(l => l.LogInformation(It.IsAny<string>()))
                .Callback<string>(message => actualMessage = message);

            var operation = new ReplaceWordOperation(
                fileManagerMock.Object,
                loggerMock.Object
            );

            // Act
            operation.Process(replaceWordData);

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}