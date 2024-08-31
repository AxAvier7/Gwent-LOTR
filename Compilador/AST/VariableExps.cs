using Tookeen;
using System.Collections.Generic;

namespace VariableExp
{
public class VariableExpression : Expression<object>
{
    public string Name { get; }
    private readonly Dictionary<string, ExpressionType> _symbolTable;

    public VariableExpression(string name, Dictionary<string, ExpressionType> symbolTable, CodeLocation location)
    {
        Name = name;
        _symbolTable = symbolTable;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        if (!_symbolTable.ContainsKey(Name))
        {
            errors.Add($"Undeclared variable: {Name} at {Location}");
            return false;
        }
        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        if (!_symbolTable.ContainsKey(Name))
        {
            error = $"Undeclared variable: {Name} at {Location}";
            return false;
        }
        error = null;
        return true;
    }

    public override object Interpret()
    {
        return _symbolTable[Name];
    }

    public override ExpressionType Return => _symbolTable[Name];

    public override string ToString() => Name;

    public override CodeLocation Location { get; protected set; }
}
}