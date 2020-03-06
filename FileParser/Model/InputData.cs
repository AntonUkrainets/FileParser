namespace FileParser.Model
{
    public class InputData
    {
        public Operation Operation { get; set; }
        public string FilePath { get; set; }
        public string SearchWord { get; set; }
        public string ReplaceableWord { get; set; }
    }
}