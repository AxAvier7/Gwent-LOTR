using Tookeen;
using Read;
using Tookeen2;
using XP;

namespace Bops{
public abstract class BinaryExpression : Expression<object>
{
    public Expression<object> Left { get; }
    public Token OperatorToken { get; }
    public Expression<object> Right { get; }
    // public CodeLocation Location { get; set; }

    public BinaryExpression(Expression<object> left, Token operatorToken, Expression<object> right, CodeLocation location)
    {
        Left = left;
        OperatorToken = operatorToken;
        Right = right;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        string leftError = null;
        string rightError = null;
        
        if (!Left.SemanticRevision(out leftError) || !Right.SemanticRevision(out rightError))
        {
            if (!string.IsNullOrEmpty(leftError))
                errors.Add(leftError);
            if (!string.IsNullOrEmpty(rightError))
                errors.Add(rightError);
            return false;
        }
        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        error = null;
        string leftError = null;
        string rightError = null;
        if (!Left.SemanticRevision(out leftError) || !Right.SemanticRevision(out rightError))
        {
            error = leftError ?? rightError;
            return false;
        }
        return true;
    }

    public abstract override object Interpret();

    public override ExpressionType Return => ExpressionType.Null;
    public override string ToString() => $"({Left} {GetOperatorSymbol()} {Right})";

    protected abstract string GetOperatorSymbol();
}

#region Bool
public class BooleanExp : BinaryExpression
{
    public TokenType Operator { get; }
    public override CodeLocation Location { get; set; }

    public BooleanExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, new Token(op, op.ToString(), location.Line, location.Column), right, location)
    {
        Operator = op;
        Location = location;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        var leftValue = (bool)Left.Interpret();
        var rightValue = (bool)Right.Interpret();
        return Operator switch
        {
            TokenType.And => leftValue && rightValue,
            TokenType.Or => leftValue || rightValue,
            _ => throw new InvalidOperationException($"Unsupported operator: {Operator}")
        };
    }

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} {Operator} {Right})";
}

#endregion Bool

#region Math
public class MathematicExp : BinaryExpression
{
    public TokenType Operator { get; }
    public override CodeLocation Location { get; set; }

    public MathematicExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, new Token(op, op.ToString(), location.Line, location.Column), right, location)
    {
        Operator = op;
        Location = location;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        return Operator switch
        {
            TokenType.Mas => leftValue + rightValue,
            TokenType.Menos => leftValue - rightValue,
            TokenType.Multiplicacion => leftValue * rightValue,
            TokenType.Division => leftValue / rightValue,
            TokenType.MasIgual => leftValue += rightValue,
            TokenType.MenosIgual => leftValue -= rightValue,
            TokenType.MultiplicacionIgual => leftValue *= rightValue,
            TokenType.DivisionIgual => leftValue /= rightValue,
            TokenType.Pow => Math.Pow(leftValue, rightValue),
            _ => throw new InvalidOperationException($"Unsupported operator: {Operator}")
        };
    }

    public override ExpressionType Return => Operator == TokenType.Mas || Operator == TokenType.Menos 
        || Operator == TokenType.Multiplicacion || Operator == TokenType.Division || Operator == TokenType.MasIgual
        || Operator == TokenType.MenosIgual || Operator == TokenType.MultiplicacionIgual
        || Operator == TokenType.DivisionIgual || Operator == TokenType.Pow
        ? ExpressionType.Number : ExpressionType.Null;
    
    public override string ToString() => $"({Left} {Operator} {Right})";
}


#endregion Math

#region Literales
public class StringBuildingExp : BinaryExpression
{
    public TokenType Operator { get; }
    public override CodeLocation Location { get; set; }

    public StringBuildingExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, new Token(op, op.ToString(), location.Line, location.Column), right, location)
    {
        Operator = op;
        Location = location;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        var leftValue = Left.Interpret().ToString();
        var rightValue = Right.Interpret().ToString();
        return Operator switch
        {
            TokenType.StringConcat => leftValue + " " + rightValue,
            TokenType.Arroba => leftValue + rightValue,
            _ => null
        };
    }

    public override ExpressionType Return => ExpressionType.Literal;    
    public override string ToString() => $"({Left} {Operator} {Right})";
}
#endregion Literales

#region Comparadores
public class GreaterThanExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public GreaterThanExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.MajorSign, ">", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        return leftValue > rightValue;
    }

    protected override string GetOperatorSymbol() => ">";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} > {Right})";
}

public class LessThanExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public LessThanExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.MinorSign, "<", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        return leftValue < rightValue;
    }

    protected override string GetOperatorSymbol() => "<";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} < {Right})";
}

public class EqualExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public EqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.Equal, "==", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Left.Interpret();
        var rightValue = Right.Interpret();
        return leftValue.Equals(rightValue);
    }

    protected override string GetOperatorSymbol() => "==";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} == {Right})";
}

public class GreaterThanOrEqualExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public GreaterThanOrEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.MajorEqual, ">=", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        return leftValue >= rightValue;
    }

    protected override string GetOperatorSymbol() => ">=";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} >= {Right})";
}

public class LessThanOrEqualExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public LessThanOrEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.MinorEqual, "<=", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        return leftValue <= rightValue;
    }

    protected override string GetOperatorSymbol() => "<=";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} <= {Right})";
}

public class NotEqualExpression : BinaryExpression
{
    public override CodeLocation Location { get; set; }

    public NotEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, new Token(TokenType.Desigual, "!=", location.Line, location.Column), right, location)
    {
        Location = location;
    }

    public override object Interpret()
    {
        var leftValue = Left.Interpret();
        var rightValue = Right.Interpret();
        return !leftValue.Equals(rightValue);
    }

    protected override string GetOperatorSymbol() => "!=";

    public override ExpressionType Return => ExpressionType.Boolean;
    public override string ToString() => $"({Left} != {Right})";
}
#endregion Comparadores
}