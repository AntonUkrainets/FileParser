using System;
using FileParser.Business.Operations.CountWords;
using FileParser.Business.Operations.ReplaceWord;
using FileParser.FilesManagers.Interfaces;
using Liba.Logger.Interfaces;
using Moq;
using Xunit;

namespace FileParserTests.Business.Operations.CountWords
{
    public class CountWordsOperationTests
    {
        #region Private Members

        private readonly CountWordsOperation countWordsOperation;

        #endregion

        public CountWordsOperationTests()
        {
            var mockFileManager = new Mock<IFileManager>();
            var mockLogger = new Mock<ILogger>();

            countWordsOperation = new CountWordsOperation(
                mockFileManager.Object,
                mockLogger.Object
            );
        }

        [Fact]
        public void Ctor()
        {
            // Assert
            Assert.IsNotType<ArgumentNullException>(countWordsOperation);
        }

        [Fact]
        public void CanProcess_Positive()
        {
            // Arrange
            var countWordsData = new CountWordsData();

            // Actual
            var actualValue = countWordsOperation.CanProcess(countWordsData);

            // Assert
            Assert.True(actualValue);
        }

        [Fact]
        public void CanProcess_Negative()
        {
            // Arrange
            var replaceWordsData = new ReplaceWordData();

            // Actual
            var actualValue = countWordsOperation.CanProcess(replaceWordsData);

            // Assert
            Assert.False(actualValue);
        }

        [Fact]
        public void Process()
        {
            // Arrange
            var text = "123 456 123 456 789 123";
            var filePath = "File.txt";

            var countWordsData = new CountWordsData
            {
                FilePath = filePath,
                SearchWord = "123"
            };

            var expectedMessage = "Count founded words: 3";

            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(m => m.ReadText(filePath))
                .Returns(text);

            var actualMessage = string.Empty;

            var loggerMock = new Mock<ILogger>();
            loggerMock
                .Setup(l => l.LogInformation(It.IsAny<string>()))
                .Callback<string>(message => actualMessage = message);

            var operation = new CountWordsOperation(
                fileManagerMock.Object,
                loggerMock.Object
            );

            // Act
            operation.Process(countWordsData);

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}