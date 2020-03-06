using FileParser.Model;

namespace FileParser.Parser
{
    public static class InputDataParser
    {
        public static InputData Parse(string[] args)
        {
            var inputData = new InputData
            {
                Operation = Operation.Count,
                FilePath = args[0],
                SearchWord = args[1]
            };

            if (args.Length == 3)
            {
                inputData.ReplaceableWord = args[2];
                inputData.Operation = Operation.Replace;
            }

            return inputData;
        }
    }
}