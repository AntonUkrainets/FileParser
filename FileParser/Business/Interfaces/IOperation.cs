using FileParser.Model;

namespace FileParser.Business.Interfaces
{
    public interface IOperation
    {
        bool CanProcess(Operation operation);
        void Process(InputData inputData);
    }
}