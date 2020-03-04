using FileParser.Files;
using FileParser.Logger.Interfaces;
using System;
using System.Linq;

namespace FileParser.OperationHandlers
{
    public class CountWordHandler : IOperationHandler
    {
        private readonly IFileManager _fileManager;
        private readonly ILogger _logger;

        public CountWordHandler(
            IFileManager fileManager,
            ILogger logger
        )
        {
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool CanProcess(InputData inputData)
        {
            return inputData.Operation == Operation.Count;
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
            var splitParameters = new char[] { ' ', '\n', '\r' };

            var splittedContent = text.Split(splitParameters, StringSplitOptions.RemoveEmptyEntries);

            return splittedContent;
        }
    }
}
