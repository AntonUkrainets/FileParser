namespace FileParser.OperationHandlers
{
    public interface IOperationHandler
    {
        bool CanProcess(Operation currentOperation);
        void Process(InputData inputData);
    }
}