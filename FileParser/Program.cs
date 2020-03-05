using FileParser.Files;
using FileParser.Logger.Implements;
using FileParser.Logger.Interfaces;
using FileParser.OperationHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileParser
{
    public class Program
    {
        #region Constants

        private const string LogPath = "application.log";

        #endregion

        #region Private Members

        private static List<IOperationHandler> _operationHandlers;
        private static ILogger _logger;

        #endregion

        public static void Main(string[] args)
        {
            try
            {
                _logger = new AggregatedLogger
                (
                    new FileLogger(LogPath),
                    new ConsoleLogger()
                );

                var inputDataParser = new InputDataParser();

                if (!inputDataParser.IsValid(args))
                {
                    ShowError();
                    return;
                }

                IFileManager fileManager = new FileManager();

                _operationHandlers = new List<IOperationHandler>
                {
                    new CountWordHandler(fileManager, _logger),
                    new ReplaceWordHandler(fileManager)
                };

                var inputData = inputDataParser.Parse(args);

                if (!IsFileValid(inputData.FilePath))
                    throw new FileNotFoundException($"File '{inputData.FilePath}' not found");

                var operationHandler = _operationHandlers.FirstOrDefault(o => o.CanProcess(inputData.Operation));

                if (operationHandler == null)
                    throw new NotSupportedException($"Operation '{inputData.Operation}' is not supported.");

                operationHandler.Process(inputData);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private static bool IsFileValid(string filePath)
        {
            return File.Exists(filePath);
        }

        private static void ShowError()
        {
            _logger.LogInformation(
                $"Input must be like <FilePath> <SearchString>;{Environment.NewLine}" +
                $"<FilePath> <SearchString> <ReplaceableString");
        }
    }
}