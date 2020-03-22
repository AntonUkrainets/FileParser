using FileParser.Model;

namespace FileParser.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IOperationData Parse(string[] args);
    }
}