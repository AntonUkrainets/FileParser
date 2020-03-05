using FileParser.Files;
using System;

namespace FileParser.OperationHandlers
{
    public class ReplaceWordHandler : IOperationHandler
    {
        #region Private Members

        private readonly IFileManager _fileManager;

        #endregion

        public ReplaceWordHandler(IFileManager fileManager)
        {
            _fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));
        }

        public bool CanProcess(Operation currentOperation)
        {
            return currentOperation == Operation.Replace;
        }

        public void Process(InputData inputData)
        {
            var text = _fileManager.ReadText(inputData.FilePath);

            text = text.Replace(inputData.SearchWord, inputData.ReplaceableWord);

            _fileManager.WriteText(inputData.FilePath, text);
        }
    }
}