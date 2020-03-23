namespace FileParser.Business.Interfaces
{
    public interface IOperation
    {
        bool CanProcess(IOperationData operationData);
        void Process(IOperationData operationData);
    }
}