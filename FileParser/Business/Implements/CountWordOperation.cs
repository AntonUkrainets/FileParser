using System;
using System.Linq;
using FileParser.Business.Interfaces;
using FileParser.Model;
using Liba.FilesManagers.Interfaces;
using Liba.Logger.Interfaces;

namespace FileParser.Business.Implements
{
    public class CountWordOperation : IOperation
    {
        #region Private Members

        private readonly IFileManager fileManager;
        private readonly ILogger logger;

        #endregion

        public CountWordOperation(
            IFileManager fileManager,
            ILogger logger
        )
        {
            this.fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));

            this.logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public bool CanProcess(Operation operation)
        {
            return operation == Operation.Count;
        }

        public void Process(InputData inputData)
        {
            var text = fileManager.ReadText();
            var words = GetWords(text);

            var count = words.Count(word => word == inputData.SearchWord);
            logger.LogInformation($"Count founded words: {count}");
        }

        private string[] GetWords(string text)
        {
            var delimeters = new char[] { ' ', '\n', '\r' };

            var words = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}