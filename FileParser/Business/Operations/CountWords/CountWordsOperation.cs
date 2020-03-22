using System;
using System.Linq;
using FileParser.Business.Interfaces;
using FileParser.FilesManagers.Interfaces;
using FileParser.Model;
using Liba.Logger.Interfaces;

namespace FileParser.Business.Operations.CountWords
{
    public class CountWordsOperation : IOperation
    {
        #region Private Members

        private readonly IFileManager fileManager;
        private readonly ILogger logger;

        #endregion

        public CountWordsOperation(
            IFileManager fileManager,
            ILogger logger
        )
        {
            this.fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));

            this.logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public bool CanProcess(IOperationData operationData)
        {
            return operationData is CountWordsData;
        }

        public void Process(IOperationData operationData)
        {
            CountWords((CountWordsData)operationData);
        }

        private void CountWords(CountWordsData operationData)
        {
            var text = fileManager.ReadText(operationData.FilePath);
            var words = GetWords(text);

            var count = words.Count(word => word == operationData.SearchWord);
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