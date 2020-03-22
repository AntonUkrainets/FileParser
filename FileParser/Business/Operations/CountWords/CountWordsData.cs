using FileParser.Model;

namespace FileParser.Business.Operations.CountWords
{
    public class CountWordsData : IOperationData
    {
        public string FilePath { get; set; }
        public string SearchWord { get; set; }
    }
}