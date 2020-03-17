using FileParser.Model;
using FileParser.Parser.Interfaces;

namespace FileParser.Parser
{
    public class CountWordsParser : IParser
    {
        public bool CanParse(int countArgs)
        {
            return countArgs == 2;
        }

        public InputData Parse(string[] args)
        {
            return new InputData
            {
                Operation = Operation.Count,
                FilePath = args[0],
                SearchWord = args[1]
            };
        }
    }
}