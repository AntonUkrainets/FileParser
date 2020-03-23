namespace FileParser.Business.Operations.ReplaceWord
{
    public class ReplaceWordData : IOperationData
    {
        public string FilePath { get; set; }
        public string SearchWord { get; set; }
        public string ReplaceableWord { get; set; }
    }
}