// public class Parser
// {
//     private readonly List<Token> _tokens;
//     private int _current;

//     public Parser(List<Token> tokens)
//     {
//         _tokens = tokens;
//         _current = 0;
//     }

//     private Token Current => _tokens[_current];
//     private Token Next => _current + 1 < _tokens.Count ? _tokens[_current + 1] : null;

//     public ProgramNode Parse()
//     {
//         var program = new ProgramNode();

//         while (Current.Type != TokenType.EOF)
//         {
//             var declaration = ParseDeclaration();
//             if (declaration != null)
//             {
//                 program.Declarations.Add(declaration);
//             }
//         }

//         return program;
//     }

//     private DeclarationNode ParseDeclaration()
//     {
//         if (Current.Type == TokenType.Card)
//         {
//             return ParseCardDeclaration();
//         }
//         return null;
//     }

//     private VariableDeclarationNode ParseVariableDeclaration()
//     {
//         var node = new VariableDeclarationNode
//         {
//             Location = new CodeLocation(Current.Line, Current.Column)
//         };

//         return node;
//     }

//     private FunctionDeclarationNode ParseFunctionDeclaration()
//     {
//         var node = new FunctionDeclarationNode
//         {
//             Location = new CodeLocation(Current.Line, Current.Column)
//         };

//         return node;
//     }
// }
