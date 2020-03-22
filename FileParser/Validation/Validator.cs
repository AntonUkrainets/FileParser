namespace FileParser.Validation
{
    public static class Validator
    {
        public static bool IsArgumentsValid(string[] args)
        {
            return (args.Length == 2) || (args.Length == 3);
        }
    }
}