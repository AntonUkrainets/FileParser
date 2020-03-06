using System.Collections.Generic;
using FileParser.Logger.Interfaces;

namespace FileParser.Logger.Implements
{
    public class AggregatedLogger : ILogger
    {
        private IEnumerable<ILogger> loggers;

        public AggregatedLogger(params ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void LogInformation(string message)
        {
            foreach (var logger in loggers)
            {
                logger.LogInformation(message);
            }
        }
    }
}