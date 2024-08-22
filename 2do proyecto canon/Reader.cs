public class Reader
{
    public static void Main()
    {
        string inputFilePath = "input.txt";
        string input = File.ReadAllText(inputFilePath);

        Lexer lexer = new Lexer(input);
        List<Token> tokens = lexer.Tokenize();

        foreach (var token in tokens)
        {
            Console.WriteLine(token);
        }

        foreach (var error in lexer.Errors)
        {
            Console.WriteLine(error);
        }
    }
}