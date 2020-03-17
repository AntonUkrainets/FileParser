using System.IO;

namespace FileParser.Validation.Implements
{
    public static class Validator
    {
        public static bool IsArgumentsValid(string[] args)
        {
            return (args.Length == 2) || (args.Length == 3);
        }

        public static bool IsFileValid(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}