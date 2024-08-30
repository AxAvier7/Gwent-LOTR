using Tookeen;

namespace Read
{
    public class Reader
    {
        public static bool ReaderErrors = false;
        public static void Main()
        {
            string inputFilePath = "input.txt";
            string input = File.ReadAllText(inputFilePath);

            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            if(lexer.Errors.Count > 0)
            {
                ReaderErrors = true;
                foreach (var error in lexer.Errors)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine("--->Fix all errors before running the code<---");
            }
            else
            {
                foreach (var token in tokens)
                {
                    Console.WriteLine(token);
                }
            }
        }
    }
}