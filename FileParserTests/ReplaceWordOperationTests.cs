using System;
using FileParser.Business.Implements;
using FileParser.Model;
using Liba.FilesManagers.Interfaces;
using Moq;
using Xunit;

namespace FileParserTests
{
    public class ReplaceWordOperationTests
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

            var handler = new ReplaceWordOperation(fileManagerMock.Object);

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

            var handler = new ReplaceWordOperation(fileManagerMock.Object);

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
                        var handler = new ReplaceWordOperation(null);
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
                        var operation = new ReplaceWordOperation(null);
                    }
            );

            // Assert
            Assert.IsType<ArgumentNullException>(actualValue);
        }
    }
}