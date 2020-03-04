using FileParser.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileParser.Logger.Implements
{
    public class AggregatedLogger : ILogger
    {
        private IEnumerable<ILogger> _loggers;

        public AggregatedLogger(params ILogger[] loggers)
        {
            _loggers = new List<ILogger>(loggers); 
        }

        public void LogInformation(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message);
            }
        }
    }
}