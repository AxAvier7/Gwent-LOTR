using Tookeen;
using Tookeen2;
using Read;
using System.Collections.Generic;

#region Condiciones
public class ConditionalExpression : Expression<object>
{
    public Expression<object> Condition { get; }
    public Expression<object> TrueBranch { get; }
    public Expression<object> FalseBranch { get; }

    public ConditionalExpression(Expression<object> condition, Expression<object> trueBranch, Expression<object> falseBranch, CodeLocation location)
    {
        Condition = condition;
        TrueBranch = trueBranch;
        FalseBranch = falseBranch;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        if (!Condition.SemanticRevision(out var conditionErrors))
        {
            errors.AddRange(new List<string> { "Errors in the conditions" });
            return false;
        }

        if (Condition.Return != ExpressionType.Boolean)
        {
            errors.Add($"Condition in 'if' statement is not a boolean at {Location}");
            return false;
        }

        if (!TrueBranch.SemanticRevision(out var trueBranchErrors))
        {
            errors.AddRange(new List<string> { "True proposition isn't totally ok" });
            return false;
        }

        if (FalseBranch != null && !FalseBranch.SemanticRevision(out var falseBranchErrors))
        {
            errors.AddRange(new List<string> { "False proposition isn't totally ok" });
            return false;
        }

        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        if (!Condition.SemanticRevision(out var conditionError))
        {
            error = conditionError;
            return false;
        }

        if (Condition.Return != ExpressionType.Boolean)
        {
            error = $"Condition in 'if' statement is not a boolean at {Location}";
            return false;
        }

        if (!TrueBranch.SemanticRevision(out var trueBranchError))
        {
            error = trueBranchError;
            return false;
        }

        if (FalseBranch != null && !FalseBranch.SemanticRevision(out var falseBranchError))
        {
            error = falseBranchError;
            return false;
        }

        error = null;
        return true;
    }

    public override object Interpret()
    {
        var conditionValue = (bool)Condition.Interpret();
        if (conditionValue)
        {
            return TrueBranch.Interpret();
        }
        else if (FalseBranch != null)
        {
            return FalseBranch.Interpret();
        }

        return null;
    }

    public override ExpressionType Return => TrueBranch.Return;

    public override string ToString() =>
        $"if ({Condition}) {{ {TrueBranch} }}" + (FalseBranch != null ? $" else {{ {FalseBranch} }}" : string.Empty);

    public override CodeLocation Location { get; protected set; }
}
#endregion Condiciones

#region Ciclos

public class WhileLoopExpression : Expression<object>
{
    public Expression<object> Condition { get; }
    public Expression<object> Body { get; }

    public WhileLoopExpression(Expression<object> condition, Expression<object> body, CodeLocation location)
    {
        Condition = condition;
        Body = body;
        Location = location;
    }

    public override object Interpret()
    {
        while ((bool)Condition.Interpret())
        {
            Body.Interpret();
        }
        return null;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();

        if (!Condition.SemanticRevision(out var conditionErrors))
        {
            errors.AddRange(new List<string> { "Conditions aren't ok" });
            return false;
        }

        if (Condition.Return != ExpressionType.Boolean)
        {
            errors.AddRange(new List<string> { $"Condition in 'while' statement is not a boolean at {Location}" });
            return false;
        }

        if (!Body.SemanticRevision(out var bodyErrors))
        {
            errors.AddRange(new List<string> { "Body of the while loop present some mistakes" });
            return false;
        }

        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        if (!Condition.SemanticRevision(out var conditionErrors))
        {
            error = string.Join(", ", conditionErrors);
            return false;
        }

        if (Condition.Return != ExpressionType.Boolean)
        {
            error = $"Condition in 'while' statement is not a boolean at {Location}";
            return false;
        }

        if (!Body.SemanticRevision(out var bodyErrors))
        {
            error = string.Join(", ", bodyErrors);
            return false;
        }

        error = null;
        return true;
    }

    public override ExpressionType Return => ExpressionType.Void;

    public override string ToString()
    {
        return $"while ({Condition}) {{ {Body} }}";
    }

    public override CodeLocation Location { get; protected set; }
}

#endregion Ciclos

#region Funciones

public class FunctionDeclarationExpression : Expression<object>
{
    public string Name { get; }
    public List<string> Parameters { get; }
    public Expression<object> Body { get; }

    public FunctionDeclarationExpression(string name, List<string> parameters, Expression<object> body, CodeLocation location)
    {
        Name = name;
        Parameters = parameters;
        Body = body;
        Location = location;
    }

    public override object Interpret()
    {
        Context.Current.SetFunction(Name, this);
        return null;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();

        if (Parameters.Count != Parameters.Distinct().Count())
        {
            errors.Add($"Semantic error: Duplicate parameter names in function '{Name}' at {Location}.");
            return false;
        }

        if (!Body.SemanticRevision(out var bodyErrors))
        {
            errors.AddRange(new List<string> { "Body of the function has some errors" });
            return false;
        }

        return true;
    }

    public override bool SemanticRevision(out string error)
    {
        if (Parameters.Count != Parameters.Distinct().Count())
        {
            error = $"Semantic error: Duplicate parameter names in function '{Name}' at {Location}.";
            return false;
        }

        if (!Body.SemanticRevision(out var bodyErrors))
        {
            error = string.Join(", ", bodyErrors);
            return false;
        }

        error = null;
        return true;
    }

    public override ExpressionType Return => ExpressionType.Function;

    public override string ToString()
    {
        var parameters = string.Join(", ", Parameters);
        return $"function {Name}({parameters}) {{ {Body} }}";
    }

    public override CodeLocation Location { get; protected set; }
}

#endregion Funciones