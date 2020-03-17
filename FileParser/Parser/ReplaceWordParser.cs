using FileParser.Model;
using FileParser.Parser.Interfaces;

namespace FileParser.Parser
{
    public class ReplaceWordParser : IParser
    {
        public bool CanParse(int countArgs)
        {
            return countArgs == 3;
        }

        public InputData Parse(string[] args)
        {
            return new InputData
            {
                Operation = Operation.Replace,
                FilePath = args[0],
                SearchWord = args[1],
                ReplaceableWord = args[2]
            };
        }
    }
}