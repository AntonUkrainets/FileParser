namespace FileParser.Validation.Interfaces
{
    public interface IValidator
    {
        bool IsArgumentsValid(string[] args);
        bool IsFileValid(string filePath);
    }
}