public class BinaryOperationExpression : Expression<object>
{
    public Expression<object> Left { get; }
    public Expression<object> Right { get; }
    public TokenType Operator { get; }

    public BinaryOperationExpression(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
    {
        Left = left;
        Right = right;
        Operator = op;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        if (!Left.RevSemantica(out var leftErrors) || !Right.RevSemantica(out var rightErrors))
        {
            errors.AddRange(leftErrors);
            errors.AddRange(rightErrors);
            return false;
        }

        if ((Operator == TokenType.Mas || Operator == TokenType.Menos || Operator == TokenType.Multiplicacion || Operator == Tokentype.Division) &&
            (Left.Return != ExpressionType.Number || Right.Return != ExpressionType.Number))
        {
            errors.Add($"Type mismatch in binary operation at {Location}");
            return false;
        }

        return true;
    }

    public override bool RevSemantica(out string error)
    {
        error = null;
        if (!Left.RevSemantica(out var leftError) || !Right.RevSemantica(out var rightError))
        {
            error = leftError ?? rightError;
            return false;
        }

        if ((Operator == TokenType.Mas || Operator == TokenType.Menos) &&
            (Left.Return != ExpressionType.Number || Right.Return != ExpressionType.Number))
        {
            error = $"Type mismatch in binary operation at {Location}";
            return false;
        }

        return true;
    }

    public override object Interpret()
    {
        var leftValue = Left.Interpret();
        var rightValue = Right.Interpret();

        switch (Operator)
        {
            case TokenType.Mas:
                return (int)leftValue + (int)rightValue;
            case TokenType.Menos:
                return (int)leftValue - (int)rightValue;
                case TokenType.Multiplicacion:
                return (int)leftValue * (int)rightValue;
            case TokenType.Division:
                return (int)leftValue / (int)rightValue;

            default:
                throw new InvalidOperationException($"Unsupported operator: {Operator}");
        }
    }

    public override ExpressionType Return => ExpressionType.Number;

    public override string ToString() => $"({Left} {Operator} {Right})";
}
