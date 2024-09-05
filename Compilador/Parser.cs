using Tookeen;
using Tookeen2;
using Read;
using Bops;
using XP;
using VariableExp;

public class Parser
{
    private readonly List<Token> _tokens;
    private int _current;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
        _current = 0;
    }

    private Token CurrentToken => _current < _tokens.Count ? _tokens[_current] : null;
    private Token Next => _current + 1 < _tokens.Count ? _tokens[_current + 1] : null;
    private void AdvanceToken() => _current++;

    private Expression<object> ParseExpression()
    {
        var expression = ParseComparison();

        while (CurrentToken != null && (CurrentToken.Type == TokenType.And || CurrentToken.Type == TokenType.Or))
        {
            var operatorToken = CurrentToken;
            AdvanceToken();

            var right = ParseComparison();
            var location = new Tookeen.CodeLocation(operatorToken.Line, operatorToken.Column);

            switch (operatorToken.Type)
            {
                case TokenType.And:
                    expression = new LogicalAndExpression(expression, right, location);
                    break;
                case TokenType.Or:
                    expression = new LogicalOrExpression(expression, right, location);
                    break;
            }
        }
        return expression;
    }


    public class LogicalAndExpression : Expression<object>
    {
        public Expression<object> Left { get; }
        public Expression<object> Right { get; }
        public override CodeLocation Location { get; set; }

        public LogicalAndExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        {
            Left = left;
            Right = right;
            Location = location;
        }
        public override bool RevSemantica(out List<string> errors)
        {
            errors = new List<string>();

            if (!Left.RevSemantica(out var leftErrors))
                errors.AddRange(leftErrors);

            if (!Right.RevSemantica(out var rightErrors))
                errors.AddRange(rightErrors);

            if (!(Left is BooleanExp) || !(Right is BooleanExp))
            {
                errors.Add($"Logical AND operation requires both operands to be boolean expressions at {Location}.");
                return false;
            }
            return errors.Count == 0;
        }

        public override bool SemanticRevision(out string error)
        {
            var errors = new List<string>();
            bool valid = RevSemantica(out errors);

            error = errors.Count > 0 ? string.Join(", ", errors) : null;
            return valid;
        }

        public override object Interpret()
        {
            var leftResult = (bool)Left.Interpret();
            var rightResult = (bool)Right.Interpret();

            return leftResult && rightResult;
        }

        public override string ToString()
        {
            return $"({Left} AND {Right})";
        }
    }

    public class LogicalOrExpression : Expression<object>
    {
        public Expression<object> Left { get; }
        public Expression<object> Right { get; }
        public override CodeLocation Location { get; set; }

        public LogicalOrExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        {
            Left = left;
            Right = right;
            Location = location;
        }

        public override bool RevSemantica(out List<string> errors)
        {
            errors = new List<string>();

            if (!Left.RevSemantica(out var leftErrors))
                errors.AddRange(leftErrors);

            if (!Right.RevSemantica(out var rightErrors))
                errors.AddRange(rightErrors);

            if (!(Left is BooleanExp) || !(Right is BooleanExp))
            {
                errors.Add($"Logical OR operation requires both operands to be boolean expressions at {Location}.");
                return false;
            }

            return errors.Count == 0;
        }

        public override bool SemanticRevision(out string error)
        {
            var errors = new List<string>();
            bool valid = RevSemantica(out errors);

            error = errors.Count > 0 ? string.Join(", ", errors) : null;
            return valid;
        }

        public override object Interpret()
        {
            var leftResult = (bool)Left.Interpret();
            var rightResult = (bool)Right.Interpret();

            return leftResult || rightResult;
        }

        public override string ToString()
        {
            return $"({Left} OR {Right})";
        }
    }

#region Ciclos
    public Expression<object> ParseIfStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        AdvanceToken();

        var condition = ParseExpression();

        if (CurrentToken.Type != TokenType.LlaveAb)
            throw new Exception($"Expected '{{' after condition at {location}");

        AdvanceToken();
        var trueBranch = ParseStatement();

        if (CurrentToken.Type != TokenType.LlaveCer)
            throw new Exception($"Expected '}}' after true branch at {location}");
        AdvanceToken();

        Expression<object> falseBranch = null;
        if (CurrentToken.Type == TokenType.Else)
        {
            AdvanceToken();

            if (CurrentToken.Type != TokenType.LlaveAb)
                throw new Exception($"Expected '{{' after 'else' at {location}");

            AdvanceToken();
            falseBranch = ParseStatement();

            if (CurrentToken.Type != TokenType.LlaveCer)
                throw new Exception($"Expected '}}' after false branch at {location}");
            AdvanceToken();
        }
        return new ConditionalExpression(condition, trueBranch, falseBranch, location);
    }

    public Expression<object> ParseWhileStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        AdvanceToken();

        var condition = ParseExpression();

        if (CurrentToken.Type != TokenType.LlaveAb)
            throw new Exception($"Expected '{{' after condition at {location}");

        AdvanceToken();
        var body = ParseStatement();

        if (CurrentToken.Type != TokenType.LlaveCer)
            throw new Exception($"Expected '}}' after body at {location}");
        AdvanceToken();

        return new WhileLoopExpression(condition, body, location);
    }

    public Expression<object> ParseForStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        AdvanceToken();

        var initialization = ParseExpression();

        if (CurrentToken.Type != TokenType.SemiColon)
            throw new Exception($"Expected ';' after initialization at {location}");
        AdvanceToken();

        var condition = ParseExpression();

        if (CurrentToken.Type != TokenType.SemiColon)
            throw new Exception($"Expected ';' after condition at {location}");
        AdvanceToken();

        var iteration = ParseExpression();

        if (CurrentToken.Type != TokenType.LlaveAb)
            throw new Exception($"Expected '{{' after iteration at {location}");

        AdvanceToken();
        var body = ParseStatement();

        if (CurrentToken.Type != TokenType.LlaveCer)
            throw new Exception($"Expected '}}' after body at {location}");
        AdvanceToken();

        return new ForLoopExpression(initialization, condition, iteration, body, location);
    }

#endregion Ciclos
    public Expression<object> ParseFunctionDeclaration()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        AdvanceToken();

        if (CurrentToken.Type != TokenType.IDs)
            throw new Exception($"Expected function name at {location}");
        var functionName = CurrentToken.Value;
        AdvanceToken();

        if (CurrentToken.Type != TokenType.ParAb)
            throw new Exception($"Expected '(' after function name at {location}");
        AdvanceToken();

        var parameters = new List<string>();
        while (CurrentToken.Type != TokenType.ParCer)
        {
            if (CurrentToken.Type != TokenType.IDs)
                throw new Exception($"Expected parameter name at {location}");
            parameters.Add(CurrentToken.Value);
            AdvanceToken();

            if (CurrentToken.Type == TokenType.Comma)
            {
                AdvanceToken();
            }
            else if (CurrentToken.Type != TokenType.ParCer)
            {
                throw new Exception($"Expected ',' or ')' after parameter at {location}");
            }
        }
        AdvanceToken();

        if (CurrentToken.Type != TokenType.LlaveAb)
            throw new Exception($"Expected '{{' before function body at {location}");
        AdvanceToken();

        var body = ParseStatement();

        if (CurrentToken.Type != TokenType.LlaveCer)
            throw new Exception($"Expected '}}' after function body at {location}");
        AdvanceToken();

        return new FunctionDeclarationExpression(functionName, parameters, body, location);
    }

    public Expression<object> ParseFunctionCall()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        if (CurrentToken.Type != TokenType.IDs)
            throw new Exception($"Expected function name at {location}");
        var functionName = CurrentToken.Value;
        AdvanceToken();

        if (CurrentToken.Type != TokenType.ParAb)
            throw new Exception($"Expected '(' after function name at {location}");
        AdvanceToken();

        var arguments = new List<Expression<object>>();
        while (CurrentToken.Type != TokenType.ParCer)
        {
            arguments.Add(ParseExpression());

            if (CurrentToken.Type == TokenType.Comma)
            {
                AdvanceToken();
            }
            else if (CurrentToken.Type != TokenType.ParCer)
            {
                throw new Exception($"Expected ',' or ')' after argument at {location}");
            }
        }
        AdvanceToken();

        return new FunctionCallExpression(functionName, arguments, location);
    }

    private Expression<object> ParseComparison()
    {
        var left = ParseAdditive();

        while (IsComparisonOperator(CurrentToken.Type))
        {
            var operatorToken = CurrentToken;
            AdvanceToken();

            var right = ParseAdditive();

            switch (operatorToken.Type)
            {
                case TokenType.MajorSign:
                    left = new GreaterThanExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
                case TokenType.MinorSign:
                    left = new LessThanExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
                case TokenType.Equal:
                    left = new EqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
                case TokenType.MajorEqual:
                    left = new GreaterThanOrEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
                case TokenType.MinorEqual:
                    left = new LessThanOrEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
                case TokenType.Desigual:
                    left = new NotEqualExpression(left, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
                    break;
            }
        }
        return left;
    }

    private bool IsComparisonOperator(TokenType tokenType)
    {
        return tokenType == TokenType.MajorSign ||
               tokenType == TokenType.MinorSign ||
               tokenType == TokenType.Equal ||
               tokenType == TokenType.MajorEqual ||
               tokenType == TokenType.MinorEqual ||
               tokenType == TokenType.Desigual;
    }

    public Tookeen2.ProgramNode Parse()
    {
        var program = new ProgramNode();

        while (CurrentToken.Type != TokenType.EOF)
        {
            var declaration = ParseDeclaration();
            if (declaration != null)
            {
                program.Declarations.Add(declaration);
            }
        }
        return program;
    }

    private DeclarationNode ParseDeclaration()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        switch (CurrentToken.Type)
        {
            case TokenType.Card:
                return ParseCardDeclaration();

            case TokenType.Variable:
                return ParseVariableDeclaration();
            default:
                throw new Exception($"Unexpected token type {CurrentToken.Type} at {location}");
        }
    }

    private VariableDeclarationNode ParseVariableDeclaration()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        var node = new VariableDeclarationNode
        {
            Location = location
        };

        if (CurrentToken.Type != TokenType.TypeIdentifier)
            throw new Exception($"Expected type identifier at {location}");
        
        node.Type = CurrentToken.Value;
        AdvanceToken();

        if (CurrentToken.Type != TokenType.IDs)
            throw new Exception($"Expected variable name at {location}");

        node.VariableName = CurrentToken.Value;
        AdvanceToken();

        if (CurrentToken.Type == TokenType.Asignacion)
        {
            AdvanceToken();
            node.InitialValue = ParseExpression();
        }

        if (CurrentToken.Type != TokenType.SemiColon)
            throw new Exception($"Expected ';' at end of variable declaration at {location}");

        AdvanceToken();
        return node;
    }
    
    private Expression<object> ParseAdditive()
    {
        var left = ParseMultiplicative();

        while (CurrentToken != null && (CurrentToken.Type == TokenType.Mas || CurrentToken.Type == TokenType.Menos))
        {
            var operatorToken = CurrentToken;
            AdvanceToken();
            var right = ParseMultiplicative();

            left = new ConcreteBinaryExpression(left, operatorToken, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
        }
        return left;
    }

    private Expression<object> ParseMultiplicative()
    {
        var left = ParsePrimary();

        while (CurrentToken != null && (CurrentToken.Type == TokenType.Multiplicacion || CurrentToken.Type == TokenType.Division))
        {
            var operatorToken = CurrentToken;
            AdvanceToken();
            var right = ParsePrimary();

            left = new ConcreteBinaryExpression(left, operatorToken, right, new CodeLocation(operatorToken.Line, operatorToken.Column));
        }

        return left;
    }

    private Expression<object> ParsePrimary()
    {
        if (CurrentToken.Type == TokenType.Number)
        {
            var value = Convert.ToDouble(CurrentToken.Value);
            AdvanceToken();
            return new LiteralExpression(value, new CodeLocation(CurrentToken.Line, CurrentToken.Column));
        }
        else if (CurrentToken.Type == TokenType.IDs)
        {
            var identifier = CurrentToken.Value;
            AdvanceToken();
            if (CurrentToken.Type == TokenType.ParAb)
            {
                return ParseFunctionCall();
            }
            return new VariableExpression(identifier, new Dictionary<string, ExpressionType>(), new CodeLocation(CurrentToken.Line, CurrentToken.Column));
        }
        else if (CurrentToken.Type == TokenType.ParAb)
        {
            AdvanceToken();
            var expression = ParseExpression();
            if (CurrentToken.Type != TokenType.ParCer)
                throw new Exception($"Expected ')' after expression at {CurrentToken.Line}:{CurrentToken.Column}");
            AdvanceToken();
            return expression;
        }
        throw new Exception($"Unexpected token: {CurrentToken.Type}");
    }

    private Expression<object> ParseStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        switch (CurrentToken.Type)
        {
            case TokenType.If:
                return ParseIfStatement();
            case TokenType.While:
                return ParseWhileStatement();
            case TokenType.For:
                return ParseForStatement();
            case TokenType.Function:
                return ParseFunctionDeclaration();
            case TokenType.IDs:
                if (Next.Type == TokenType.Asignacion)
                {
                    return ParseAssignment();
                }
                else if (Next.Type == TokenType.ParAb)
                {
                    return ParseFunctionCall();
                }
                else
                {
                    return ParseExpression();
                }
            case TokenType.Return:
                return ParseReturnStatement();
            case TokenType.Break:
                return ParseBreakStatement();
            case TokenType.Continue:
                return ParseContinueStatement();
            default:
                throw new Exception($"Unexpected token: {CurrentToken.Type} at {location}");
        }
    }

    private Expression<object> ParseAssignment()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);

        var variableName = CurrentToken.Value;
        AdvanceToken();

        if (CurrentToken.Type != TokenType.Asignacion)
            throw new Exception($"Expected '=' after variable name at {location}");
        AdvanceToken();

        var value = ParseExpression();

        return new AssignmentExpression(variableName, value, location);
    }

    private Expression<object> ParseReturnStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);
        AdvanceToken();
        var value = ParseExpression();
        return new ReturnExpression(value, location);
    }

    private Expression<object> ParseBreakStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);
        AdvanceToken();
        return new BreakExpression(location);
    }

    private Expression<object> ParseContinueStatement()
    {
        var location = new CodeLocation(CurrentToken.Line, CurrentToken.Column);
        AdvanceToken();
        return new ContinueExpression(location);
    }

    private DeclarationNode ParseCardDeclaration()
    {
        ExpectToken(TokenType.Keyword, "Card");

        string cardName = ExpectToken(TokenType.String).Value;

        ExpectToken(TokenType.TwoPoints, "Faction");
        string faction = ExpectToken(TokenType.String).Value;
        if (!IsValidFaction(faction))
        {
            throw new ParseException($"Invalid faction: {faction}");
        }

        ExpectToken(TokenType.TwoPoints, "Type");
        string type = ExpectToken(TokenType.String).Value;
        if (!IsValidType(type))
        {
            throw new ParseException($"Invalid type: {type}");
        }

        ExpectToken(TokenType.TwoPoints, "Range");
        string range = ExpectToken(TokenType.String).Value;
        if (!IsValidRange(range))
        {
            throw new ParseException($"Invalid range: {range}");
        }

        ExpectToken(TokenType.TwoPoints, "Power");
        int power = int.Parse(ExpectToken(TokenType.Number).Value);

        return new DeclarationNode
        {
            Name = cardName,
            Faction = faction,
            Type = type,
            Range = range,
            Power = power
        };
    }

    private bool IsValidFaction(string faction)
    {
        return faction == "Mordor" || faction == "Comunidad del Anillo" || faction == "None";
    }

    private bool IsValidType(string type)
    {
        return type == "Oro" || type == "Plata" || type == "Lider" || type == "Aumento" || type == "Clima";
    }

    private bool IsValidRange(string range)
    {
        return range == "Melee" || range == "Ranged" || range == "Siege";
    }

    public class DeclarationNode
    {
        public string Name { get; set; }
        public string Faction { get; set; }
        public string Type { get; set; }
        public string Range { get; set; }
        public int Power { get; set; }
    }


    private Token ExpectToken(TokenType expectedType, string expectedValue = null)
    {
        if (CurrentToken.Type != expectedType || (expectedValue != null && CurrentToken.Value != expectedValue))
        {
            throw new ParseException($"Expected {expectedType} token with value '{expectedValue}', but found {CurrentToken.Type} with value '{CurrentToken.Value}'.");
        }

        Token token = CurrentToken;
        AdvanceToken();
        return token;
    }

    public class ParseException : Exception
    {
        public ParseException(string message) : base(message) { }
    }

}
