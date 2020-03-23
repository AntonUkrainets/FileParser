using FileParser.Business;
using FileParser.Business.Operations.CountWords;
using FileParser.Parser.Interfaces;

namespace FileParser.Parser
{
    public class CountWordsParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 2;
        }

        public IOperationData Parse(string[] args)
        {
            return new CountWordsData
            {
                FilePath = args[0],
                SearchWord = args[1]
            };
        }
    }
}