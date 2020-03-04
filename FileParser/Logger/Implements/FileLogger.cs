using FileParser.Logger.Interfaces;
using System;
using System.IO;

namespace FileParser.Logger.Implements
{
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void LogInformation(string message)
        {
            File.AppendAllText(_filePath, $"{DateTime.UtcNow.ToString("yyyyMMdd HH:mm:ss")} {message}{Environment.NewLine}");
        }
    }
}