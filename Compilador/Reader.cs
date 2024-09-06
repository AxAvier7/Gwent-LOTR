using Tookeen;
using Tookeen2;
using Bops;
using XP;
using VariableExp;
using System.Collections.Generic;
using System.IO;

namespace Read
{
    public class Reader
    {
        public static bool ReaderErrors = false;

        public static void Main()
        {
            string inputFilePath = "input.txt";
            string input = File.ReadAllText(inputFilePath);

            // Lexer: tokenización del archivo de entrada
            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            if (lexer.Errors.Count > 0)
            {
                ReaderErrors = true;
                foreach (var error in lexer.Errors)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine("--->Fix all errors before running the code<---");
                return;
            }

            // Mostrar los tokens generados
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            // Parser parser = new Parser(tokens);
            // ProgramNode programNode;
            // try
            // {
            //     programNode = parser.ParseProgram();
            //     Console.WriteLine("Parsing completed successfully.");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Parsing error: {ex.Message}");
            //     return;
            // }

            // try
            // {
            //     programNode.RevSemantica();
            //     Console.WriteLine("Semantic revision completed successfully.");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Semantic error: {ex.Message}");
            //     return;
            // }

            // try
            // {
            //     var context = Context.Current;
            //     programNode.Interpret(context);
            //     Console.WriteLine("Execution completed successfully.");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Execution error: {ex.Message}");
            // }
        }
    }
}