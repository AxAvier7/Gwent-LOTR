using Tookeen;
using Tookeen2;
using Read;
using System.Collections.Generic;

namespace XP
{
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

public class ForLoopExpression : Expression<object>
{
    public Expression<object> Initialization { get; }
    public Expression<object> Condition { get; }
    public Expression<object> Iteration { get; }
    public Expression<object> Body { get; }
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.ForLoop;

    public ForLoopExpression(Expression<object> initialization, Expression<object> condition, Expression<object> iteration, Expression<object> body, CodeLocation location)
    {
        Initialization = initialization;
        Condition = condition;
        Iteration = iteration;
        Body = body;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();

        if (!Initialization.RevSemantica(out var initErrors))
            errors.AddRange(initErrors);

        if (!Condition.RevSemantica(out var condErrors))
            errors.AddRange(condErrors);

        if (!Iteration.RevSemantica(out var iterErrors))
            errors.AddRange(iterErrors);

        if (!Body.RevSemantica(out var bodyErrors))
            errors.AddRange(bodyErrors);

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
        return null;
    }

    public override string ToString()
    {
        return $"for ({Initialization}; {Condition}; {Iteration}) {{ {Body} }}";
    }
}

public class ContinueExpression : Expression<object>
{
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.Continue;

    public ContinueExpression(CodeLocation location)
    {
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        return true;
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
        return null;
    }

    public override string ToString()
    {
        return "continue";
    }
}


public class BreakExpression : Expression<object>
{
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.Break;

    public BreakExpression(CodeLocation location)
    {
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        return true;
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
        return null;
    }

    public override string ToString()
    {
        return "break";
    }
}

public class ReturnExpression : Expression<object>
{
    public Expression<object> Value { get; }
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.Return;

    public ReturnExpression(Expression<object> value, CodeLocation location)
    {
        Value = value;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        return true;
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
        return Value.Interpret();
    }

    public override string ToString()
    {
        return $"return {Value}";
    }
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

public class FunctionCallExpression : Expression<object>
{
    public string FunctionName { get; }
    public List<Expression<object>> Arguments { get; }
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.FunctionCall;

    public FunctionCallExpression(string functionName, List<Expression<object>> arguments, CodeLocation location)
    {
        FunctionName = functionName;
        Arguments = arguments;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();

        foreach (var argument in Arguments)
        {
            if (!argument.RevSemantica(out var argErrors))
                errors.AddRange(argErrors);
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
        return null;
    }

    public override string ToString()
    {
        var args = string.Join(", ", Arguments);
        return $"{FunctionName}({args})";
    }
}

#endregion Funciones

#region Asignacion
public class AssignmentExpression : Expression<object>
{
    public string VariableName { get; }
    public Expression<object> Value { get; }
    public override CodeLocation Location { get; protected set; }
    public override ExpressionType Return => ExpressionType.Assignment;

    public AssignmentExpression(string variableName, Expression<object> value, CodeLocation location)
    {
        VariableName = variableName;
        Value = value;
        Location = location;
    }

    public override bool RevSemantica(out List<string> errors)
    {
        errors = new List<string>();
        return true;
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
        return null;
    }

    public override string ToString()
    {
        return $"{VariableName} = {Value}";
    }
}
#endregion Asignacion

}