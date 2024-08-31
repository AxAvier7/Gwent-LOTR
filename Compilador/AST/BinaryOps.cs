using Tookeen;
using Read;
using Tookeen2;

namespace Bops{
public abstract class BinaryExpression : Expression<object>
{
    public Expression<object> Left { get; }
    public Expression<object> Right { get; }

    protected BinaryExpression(Expression<object> left, Expression<object> right, CodeLocation location)
    {
        Left = left;
        Right = right;
        Location = location;
    }

    public override CodeLocation Location {get; protected set;}

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

    public override ExpressionType Return => ExpressionType.Number;

    public override string ToString() => $"({Left} {GetOperatorSymbol()} {Right})";

    protected abstract string GetOperatorSymbol();
}

#region Bool
public class BooleanExp : BinaryExpression
{
    public TokenType Operator { get; }

    public BooleanExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, right, location)
    {
        Operator = op;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        var leftValue = Left;
        var rightValue = Right;
        switch (Operator)
        {
            case TokenType.And:
                return (bool)leftValue.Interpret() && (bool)rightValue.Interpret();
            case TokenType.Or:
                return (bool)leftValue.Interpret() || (bool)rightValue.Interpret();
            default:
                throw new InvalidOperationException($"Unsupported operator: {Operator}");
                return null;
        }
    }

    public override ExpressionType Return => Operator == TokenType.And || Operator == TokenType.Or 
        ? ExpressionType.Boolean : ExpressionType.Null;
    
    public override string ToString() => $"({Left} {Operator} {Right})";
}

#endregion Bool

#region Math
public class MathematicExp : BinaryExpression
{
    public TokenType Operator { get; }

    public MathematicExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, right, location)
    {
        Operator = op;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        var leftValue = Convert.ToDouble(Left.Interpret());
        var rightValue = Convert.ToDouble(Right.Interpret());
        switch (Operator)
        {
            case TokenType.Mas:
                return leftValue + rightValue;
            case TokenType.Menos:
                return leftValue - rightValue;
            case TokenType.Multiplicacion:
                return leftValue * rightValue;
            case TokenType.Division:
                return leftValue / rightValue;
            case TokenType.MasIgual:
                return leftValue += rightValue;
            case TokenType.MenosIgual:
                return leftValue -= rightValue;
            case TokenType.MultiplicacionIgual:
                return leftValue *= rightValue;
            case TokenType.DivisionIgual:
                return leftValue /= rightValue;
            case TokenType.Pow:
                return Math.Pow(leftValue, rightValue);
            default:
                throw new InvalidOperationException($"Unsupported operator: {Operator}");
        }
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

    public StringBuildingExp(Expression<object> left, Expression<object> right, TokenType op, CodeLocation location)
        : base(left, right, location)
    {
        Operator = op;
    }

    protected override string GetOperatorSymbol()
    {
        return Operator.ToString();
    }

    public override object Interpret()
    {
        if (Operator == TokenType.StringConcat)
        {
            var leftValue = Left.Interpret().ToString();
            var rightValue = Right.Interpret().ToString();
            return leftValue + " " + rightValue;
        }
        if (Operator == TokenType.Arroba)
        {
            var leftValue = Left.Interpret().ToString();
            var rightValue = Right.Interpret().ToString();
            return leftValue + rightValue;
        }
        else return null;
    }

    public override ExpressionType Return => Operator == TokenType.Arroba || Operator == TokenType.StringConcat 
        ? ExpressionType.Literal : ExpressionType.Null;
    
    public override string ToString() => $"({Left} {Operator} {Right})";
}

#endregion Literales

#region Comparadores
public class GreaterThanExpression : BinaryExpression
{
    public GreaterThanExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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
    public LessThanExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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
    public EqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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
    public GreaterThanOrEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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
    public LessThanOrEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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
    public NotEqualExpression(Expression<object> left, Expression<object> right, CodeLocation location)
        : base(left, right, location) { }

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