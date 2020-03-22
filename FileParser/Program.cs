using System;
using FileParser.Core;
using FileParser.Validation;
using Liba.Logger;
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

            var environment = new AppEnvironment(logger);

            try
            {
                if (!Validator.IsArgumentsValid(args))
                {
                    logger.LogInformation(
                        $"Input must be like <FilePath> <SearchString>;{Environment.NewLine}" +
                        $"<FilePath> <SearchString> <ReplaceableString");

                    return;
                }

                var inputData = environment.Parse(args);

                environment.Run(inputData);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
        }
    }
}