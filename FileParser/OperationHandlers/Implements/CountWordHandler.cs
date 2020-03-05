using FileParser.Files;
using FileParser.Logger.Interfaces;
using System;
using System.Linq;

namespace FileParser.OperationHandlers
{
    public class CountWordHandler : IOperationHandler
    {
        #region Private Members

        private readonly IFileManager _fileManager;
        private readonly ILogger _logger;

        #endregion

        public CountWordHandler(
            IFileManager fileManager,
            ILogger logger
        )
        {
            _fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public bool CanProcess(Operation currentOperation)
        {
            return currentOperation == Operation.Count;
        }

        public void Process(InputData inputData)
        {
            var text = _fileManager.ReadText(inputData.FilePath);
            var words = GetWords(text);

            var count = words.Count(w => w == inputData.SearchWord);
            _logger.LogInformation($"Count founded words: {count}");
        }

        private string[] GetWords(string text)
        {
            var delimeters = new char[] { ' ', '\n', '\r' };

            var words = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}