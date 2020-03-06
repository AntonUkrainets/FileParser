using System.IO;
using FileParser.Validation.Interfaces;

namespace FileParser.Validation.Implements
{
    public class Validator : IValidator
    {
        public bool IsArgumentsValid(string[] args)
        {
            return (args.Length == 2) || (args.Length == 3);
        }

        public bool IsFileValid(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}