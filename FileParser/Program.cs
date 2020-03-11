using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileParser.Business;
using FileParser.Business.Implements;
using FileParser.Business.Interfaces;
using FileParser.Parser;
using FileParser.Validation.Implements;
using Liba.FilesManagers.Implements;
using Liba.FilesManagers.Interfaces;
using Liba.Logger.Implements;
using Liba.Logger.Interfaces;

namespace FileParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logPath = "application.log";

            ILogger logger = new AggregatedLogger
                (
                    new FileLogger(logPath),
                    new ConsoleLogger()
                );

            try
            {
                var validator = new Validator();

                if (!validator.IsArgumentsValid(args))
                {
                    logger.LogInformation(
                        $"Input must be like <FilePath> <SearchString>;{Environment.NewLine}" +
                        $"<FilePath> <SearchString> <ReplaceableString");

                    return;
                }

                var inputData = InputDataParser.Parse(args);

                if (!validator.IsFileValid(inputData.FilePath))
                    throw new FileNotFoundException($"File '{inputData.FilePath}' not found");

                IFileManager fileManager = new FileManager(inputData.FilePath);

                var operations = new List<IOperation>
                {
                    new CountWordOperation(fileManager, logger),
                    new ReplaceWordOperation(fileManager)
                };

                var operation = operations.FirstOrDefault(o => o.CanProcess(inputData.Operation));

                if (operation == null)
                    throw new NotSupportedException($"Operation '{inputData.Operation}' is not supported.");

                operation.Process(inputData);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
        }
    }
}