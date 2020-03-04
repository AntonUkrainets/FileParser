namespace FileParser
{
    public class InputDataParser
    {
        public bool IsValid(string[] args)
        {
            return (args.Length == 2) || (args.Length == 3);
        }

        public InputData Parse(string[] args)
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