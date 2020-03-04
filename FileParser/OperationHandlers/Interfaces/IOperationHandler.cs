namespace FileParser.OperationHandlers
{
    public interface IOperationHandler
    {
        bool CanProcess(InputData inputData);
        void Process(InputData inputData);
    }
}