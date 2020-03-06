using System;
using FileParser.Logger.Interfaces;

namespace FileParser.Logger.Implements
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy.MMd.d HH:mm:ss")} {message}");
        }
    }
}