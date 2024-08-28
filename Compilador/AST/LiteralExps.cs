public class LiteralExpression : Expression<object>
{
    public object Value { get; }

    public LiteralExpression(object value, CodeLocation location)
    {
        Value = value;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        return true;
    }

    public override bool RevSemantica(out string error)
    {
        error = null;
        return true;
    }

    public override object Interpret() => Value;

    public override ExpressionType Return => ExpressionType.Literal;

    public override string ToString() => Value.ToString();
}