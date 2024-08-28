using Tookeen;

namespace Read
{

    abstract class Expression<T>
    {
        public abstract bool RevSemantica(out List<string> errors);
        public abstract bool RevSemantica(out string error);
        public abstract T Interpret();
        public abstract ExpressionType Return { get; }
        public abstract CodeLocation Location { get; protected set; }
        public abstract string ToString();
    }


    public class Reader
    {
        public bool ReaderErrors = false;
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