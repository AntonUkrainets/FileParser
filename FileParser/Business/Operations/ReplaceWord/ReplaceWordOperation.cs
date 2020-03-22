using System;
using FileParser.Business.Interfaces;
using FileParser.FilesManagers.Interfaces;
using FileParser.Model;
using Liba.Logger.Interfaces;

namespace FileParser.Business.Operations.ReplaceWord
{
    public class ReplaceWordOperation : IOperation
    {
        #region Private Members

        private readonly IFileManager fileManager;
        private readonly ILogger logger;

        #endregion

        public ReplaceWordOperation(
            IFileManager fileManager,
            ILogger logger)
        {
            this.fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));

            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));
        }

        public bool CanProcess(IOperationData operationData)
        {
            return operationData is ReplaceWordData;
        }

        public void Process(IOperationData operationData)
        {
            ReplaceWord((ReplaceWordData)operationData);
        }

        private void ReplaceWord(ReplaceWordData operationData)
        {
            var text = fileManager.ReadText(operationData.FilePath);

            text = text.Replace(operationData.SearchWord, operationData.ReplaceableWord);

            fileManager.WriteText(operationData.FilePath, text);
            logger.LogInformation($"The word {operationData.SearchWord} was changed on {operationData.ReplaceableWord}");
        }
    }
}