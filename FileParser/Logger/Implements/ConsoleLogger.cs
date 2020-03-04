using FileParser.Logger.Interfaces;
using System;

namespace FileParser.Logger.Implements
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("yyyyMMdd HH:mm:ss")} {message}");
        }
    }
}