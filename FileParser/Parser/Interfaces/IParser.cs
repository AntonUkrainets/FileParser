using FileParser.Business;

namespace FileParser.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IOperationData Parse(string[] args);
    }
}