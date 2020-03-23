using System;
using System.Linq;
using FileParser.Business;
using FileParser.Business.Interfaces;
using FileParser.Business.Operations.CountWords;
using FileParser.Business.Operations.ReplaceWord;
using FileParser.FilesManagers;
using FileParser.FilesManagers.Interfaces;
using FileParser.Parser;
using FileParser.Parser.Interfaces;
using Liba.Logger.Interfaces;

namespace FileParser.Core
{
    public class AppEnvironment
    {
        private readonly ILogger logger;
        private readonly IParser[] inputDataParsers;
        private readonly IOperation[] operations;

        public AppEnvironment(ILogger logger)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            inputDataParsers = new IParser[]
            {
                new CountWordsParser(),
                new ReplaceWordParser()
            };

            operations = GetOperations();
        }

        private IOperation[] GetOperations()
        {
            IFileManager fileManager = new FileManager();

            var operations = new IOperation[]
            {
                new CountWordsOperation(fileManager, logger),
                new ReplaceWordOperation(fileManager, logger)
            };

            return operations;
        }

        public IOperationData Parse(string[] args)
        {
            var parser = inputDataParsers
                .FirstOrDefault(p => p.CanParse(args));

            var inputData = parser.Parse(args);

            return inputData;
        }

        public void Run(IOperationData operationData)
        {
            var operation = operations
                .FirstOrDefault(o => o.CanProcess(operationData));

            if (operation == null)
                throw new NotSupportedException($"Operation '{operationData}' is not supported.");

            operation.Process(operationData);
        }
    }
}