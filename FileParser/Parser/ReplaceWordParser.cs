using FileParser.Business;
using FileParser.Business.Operations.ReplaceWord;
using FileParser.Parser.Interfaces;

namespace FileParser.Parser
{
    public class ReplaceWordParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 3;
        }

        public IOperationData Parse(string[] args)
        {
            return new ReplaceWordData
            {
                FilePath = args[0],
                SearchWord = args[1],
                ReplaceableWord = args[2]
            };
        }
    }
}