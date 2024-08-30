// using Tookeen;
// using Tookeen2;
// using Read;

// public class Parser
// {
//     private readonly List<Token> _tokens;
//     private int _current;

//     public Parser(List<Token> tokens)
//     {
//         _tokens = tokens;
//         _current = 0;
//     }

//     private Token CurrentToken => _currentPosition < _tokens.Count ? _tokens[_currentPosition] : null;    private Token Next => _current + 1 < _tokens.Count ? _tokens[_current + 1] : null;
//     private void AdvanceToken() => _currentPosition++;
    
//     public Expression<object> ParseIfStatement()
//     {
//         var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

//         // Consume the 'if' token
//         AdvanceToken();

//         // Parse the condition
//         var condition = ParseExpression();

//         // Expecting a '{' after the condition
//         if (CurrentToken.Type != TokenType.LlaveAb)
//             throw new Exception($"Expected '{{' after condition at {location}");

//         // Parse the true branch (inside the braces)
//         AdvanceToken(); // consume '{'
//         var trueBranch = ParseStatement();

//         // Expecting a '}' after the true branch
//         if (CurrentToken.Type != TokenType.LlaveCer)
//             throw new Exception($"Expected '}}' after true branch at {location}");
//         AdvanceToken(); // consume '}'

//         // Parse the false branch if 'else' is present
//         Expression<object> falseBranch = null;
//         if (CurrentToken.Type == TokenType.Else)
//         {
//             AdvanceToken(); // consume 'else'

//             if (CurrentToken.Type != TokenType.LlaveAb)
//                 throw new Exception($"Expected '{{' after 'else' at {location}");

//             AdvanceToken(); // consume '{'
//             falseBranch = ParseStatement();

//             if (CurrentToken.Type != TokenType.LlaveCer)
//                 throw new Exception($"Expected '}}' after false branch at {location}");
//             AdvanceToken(); // consume '}'
//         }
//         return new ConditionalExpression(condition, trueBranch, falseBranch, location);
//     }

//     public Expression<object> ParseWhileStatement()
//     {
//         var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

//         // Consume the 'while' token
//         AdvanceToken();

//         // Parse the condition
//         var condition = ParseExpression();

//         // Expecting a '{' after the condition
//         if (CurrentToken.Type != TokenType.LlaveAb)
//             throw new Exception($"Expected '{{' after condition at {location}");

//         // Parse the body
//         AdvanceToken(); // consume '{'
//         var body = ParseStatement();

//         // Expecting a '}' after the body
//         if (CurrentToken.Type != TokenType.LlaveCer)
//             throw new Exception($"Expected '}}' after body at {location}");
//         AdvanceToken(); // consume '}'

//         return new WhileLoopExpression(condition, body, location);
//     }

//     public Expression<object> ParseForStatement()
//     {
//         var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

//         // Consume the 'for' token
//         AdvanceToken();

//         // Parse the initialization statement
//         var initialization = ParseExpression();

//         // Expect a semicolon
//         if (CurrentToken.Type != TokenType.SemiColon)
//             throw new Exception($"Expected ';' after initialization at {location}");
//         AdvanceToken(); // consume ';'

//         // Parse the condition
//         var condition = ParseExpression();

//         // Expect another semicolon
//         if (CurrentToken.Type != TokenType.SemiColon)
//             throw new Exception($"Expected ';' after condition at {location}");
//         AdvanceToken(); // consume ';'

//         // Parse the iteration statement
//         var iteration = ParseExpression();

//         // Expecting a '{' after the iteration statement
//         if (CurrentToken.Type != TokenType.LlaveAb)
//             throw new Exception($"Expected '{{' after iteration at {location}");

//         // Parse the body
//         AdvanceToken(); // consume '{'
//         var body = ParseStatement();

//         // Expecting a '}' after the body
//         if (CurrentToken.Type != TokenType.LlaveCer)
//             throw new Exception($"Expected '}}' after body at {location}");
//         AdvanceToken(); // consume '}'

//         return new ForLoopExpression(initialization, condition, iteration, body, location);
//     }

//     public Expression<object> ParseFunctionDeclaration()
//     {
//         var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

//         // Consume the 'function' keyword
//         AdvanceToken();

//         // Expecting the function name
//         if (CurrentToken.Type != TokenType.IDs)
//             throw new Exception($"Expected function name at {location}");
//         var functionName = CurrentToken.Value;
//         AdvanceToken(); // consume function name

//         // Expecting '(' after the function name
//         if (CurrentToken.Type != TokenType.ParAb)
//             throw new Exception($"Expected '(' after function name at {location}");
//         AdvanceToken(); // consume '('

//         // Parse parameters
//         var parameters = new List<string>();
//         while (CurrentToken.Type != TokenType.ParCer)
//         {
//             if (CurrentToken.Type != TokenType.IDs)
//                 throw new Exception($"Expected parameter name at {location}");
//             parameters.Add(CurrentToken.Value);
//             AdvanceToken(); // consume parameter name

//             if (CurrentToken.Type == TokenType.Comma)
//             {
//                 AdvanceToken(); // consume ','
//             }
//             else if (CurrentToken.Type != TokenType.ParCer)
//             {
//                 throw new Exception($"Expected ',' or ')' after parameter at {location}");
//             }
//         }
//         AdvanceToken(); // consume ')'

//         // Expecting '{' before the function body
//         if (CurrentToken.Type != TokenType.LlaveAb)
//             throw new Exception($"Expected '{{' before function body at {location}");
//         AdvanceToken(); // consume '{'

//         // Parse the function body
//         var body = ParseStatement();

//         // Expecting '}' after the function body
//         if (CurrentToken.Type != TokenType.LlaveCer)
//             throw new Exception($"Expected '}}' after function body at {location}");
//         AdvanceToken(); // consume '}'

//         return new FunctionDeclarationExpression(functionName, parameters, body, location);
//     }

//     public Expression<object> ParseFunctionCall()
//     {
//         var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

//         // Expecting the function name
//         if (CurrentToken.Type != TokenType.IDs)
//             throw new Exception($"Expected function name at {location}");
//         var functionName = CurrentToken.Value;
//         AdvanceToken(); // consume function name

//         // Expecting '(' after the function name
//         if (CurrentToken.Type != TokenType.ParAb)
//             throw new Exception($"Expected '(' after function name at {location}");
//         AdvanceToken(); // consume '('

//         // Parse arguments
//         var arguments = new List<Expression<object>>();
//         while (CurrentToken.Type != TokenType.ParCer)
//         {
//             arguments.Add(ParseExpression());

//             if (CurrentToken.Type == TokenType.Comma)
//             {
//                 AdvanceToken(); // consume ','
//             }
//             else if (CurrentToken.Type != TokenType.ParCer)
//             {
//                 throw new Exception($"Expected ',' or ')' after argument at {location}");
//             }
//         }
//         AdvanceToken(); // consume ')'

//         return new FunctionCallExpression(functionName, arguments, location);
//     }

//     private Expression<object> ParseComparison()
//     {
//         var left = ParseAdditive(); // assuming ParseAdditive handles +, - operations

//         while (IsComparisonOperator(CurrentToken.Type))
//         {
//             var operatorToken = CurrentToken;
//             AdvanceToken();

//             var right = ParseAdditive();

//             switch (operatorToken.Type)
//             {
//                 case TokenType.MajorSign:
//                     left = new GreaterThanExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//                 case TokenType.MinorSign:
//                     left = new LessThanExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//                 case TokenType.Equal:
//                     left = new EqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//                 case TokenType.MajorEqual:
//                     left = new GreaterThanOrEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//                 case TokenType.MinorEqual:
//                     left = new LessThanOrEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//                 case TokenType.Desigual:
//                     left = new NotEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
//                     break;
//             }
//         }
//         return left;
//     }

//     private bool IsComparisonOperator(TokenType tokenType)
//     {
//         return tokenType == TokenType.MajorSign ||
//                tokenType == TokenType.MinorSign ||
//                tokenType == TokenType.Equal ||
//                tokenType == TokenType.MajorEqual ||
//                tokenType == TokenType.MinorEqual ||
//                tokenType == TokenType.Desigual;
//     }
    
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

// }