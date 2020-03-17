using FileParser.Model;

namespace FileParser.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(int countArgs);
        InputData Parse(string[] args);
    }
}