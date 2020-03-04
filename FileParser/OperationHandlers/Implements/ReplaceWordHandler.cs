using FileParser.Files;
using System;

namespace FileParser.OperationHandlers
{
    public class ReplaceWordHandler : IOperationHandler
    {
        private readonly IFileManager _fileManager;

        public ReplaceWordHandler(IFileManager fileManager)
        {
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
        }

        public bool CanProcess(InputData inputData)
        {
            return inputData.Operation == Operation.Replace;
        }

        public void Process(InputData inputData)
        {
            var text = _fileManager.ReadText(inputData.FilePath);

            text = text.Replace(inputData.SearchWord, inputData.ReplaceableWord);

            _fileManager.WriteText(inputData.FilePath, text);
        }
    }
}