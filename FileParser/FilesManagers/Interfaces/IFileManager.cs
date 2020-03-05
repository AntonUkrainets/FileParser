namespace FileParser.Files
{
    public interface IFileManager
    {
        string ReadText(string filePath);
        void WriteText(string filePath, string text);
    }
}