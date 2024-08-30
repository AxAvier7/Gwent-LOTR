using Read;
using Tookeen;
using Tookeen2;
public class UnaryOperationExpression : Expression<object>
{
    public Expression<object> Operand { get; }
    public TokenType Operator { get; }

    public override CodeLocation Location { get; protected set; }

    public UnaryOperationExpression(Expression<object> operand, TokenType op, CodeLocation location)
    {
        Operand = operand;
        Operator = op;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        if (!Operand.RevSemantica(out var operandErrors))
        {
            errors.AddRange(operandErrors);
            return false;
        }

        if (Operand.Return != ExpressionType.Number)
        {
            errors.Add($"Type mismatch in unary operation at {Location}");
            return false;
        }

        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        if (!Operand.SemanticRevision(out var operandError))
        {
            error = operandError;
            return false;
        }

        if (Operand.Return != ExpressionType.Number)
        {
            error = $"Type mismatch in unary operation at {Location}";
            return false;
        }

        error = null;
        return true;
    }

    public override object Interpret()
    {
        var value = Convert.ToDouble(Operand.Interpret());

        switch (Operator)
        {
            case TokenType.MasMas:
                return value + 1;
            case TokenType.MenosMenos:
                return value - 1;
            default:
                throw new InvalidOperationException($"Unsupported operator: {Operator}");
        }
    }

    public override ExpressionType Return => ExpressionType.Number;

    public override string ToString() => $"({Operator}{Operand})";
}
