// public double Evaluar(List<Token> tokens)
//     {
//         Stack<double> values = new Stack<double>();
//         Stack<Token> operators = new Stack<Token>();

//         foreach (var token in tokens)
//         {
//             if (token.Type == TokenType.Number)
//             {
//                 values.Push(double.Parse(token.Value));
//             }
//             else if (token.Type == TokenType.Mas || token.Type == TokenType.Menos || token.Type == TokenType.Multiplicacion || token.Type == TokenType.Division)
//             {
//                 while (operators.Count > 0 && Precedencia(token, operators.Peek()))
//                 {
//                     values.Push(Operar(operators.Pop(), values.Pop(), values.Pop()));
//                 }
//                 operators.Push(token);
//             }
//         }

//         while (operators.Count > 0)
//         {
//             values.Push(Operar(operators.Pop(), values.Pop(), values.Pop()));
//         }

//         return values.Pop();
//     }

//     private bool Precedencia(Token current, Token top)
//     {
//         if (top.Type == TokenType.Multiplicacion || top.Type == TokenType.Division)
//         {
//             return true;
//         }

//         if (current.Type == TokenType.Multiplicacion || current.Type == TokenType.Division)
//         {
//             return false;
//         }

//         return true;
//     }

//     private double Operar(Token op, double b, double a)
//     {
//         return op.Type switch
//         {
//             TokenType.Mas => a + b,
//             TokenType.Menos => a - b,
//             TokenType.Multiplicacion => a * b,
//             TokenType.Division => a / b,
//             _ => throw new InvalidOperationException("Operador desconocido")
//         };
//     }