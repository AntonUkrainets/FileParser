using System.IO;

namespace FileParser.Files
{
    public class FileManager : IFileManager
    {
        public string ReadText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void WriteText(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}