using Bops;
using XP;

public class Scope
{
    private readonly Dictionary<string, object> _variables;
    private readonly Dictionary<string, FunctionDeclarationExpression> _functions;
    private readonly Scope _parentScope;

    public Scope(Scope parentScope = null)
    {
        _variables = new Dictionary<string, object>();
        _functions = new Dictionary<string, FunctionDeclarationExpression>();
        _parentScope = parentScope;
    }

    public void SetVariable(string name, object value)
    {
        if (_variables.ContainsKey(name))
        {
            _variables[name] = value;
        }
        else if (_parentScope != null && _parentScope.HasVariable(name))
        {
            _parentScope.SetVariable(name, value);
        }
        else
        {
            _variables[name] = value;
        }
    }

    public object GetVariable(string name)
    {
        if (_variables.TryGetValue(name, out var value))
        {
            return value;
        }
        else if (_parentScope != null)
        {
            return _parentScope.GetVariable(name);
        }
        else
        {
            throw new Exception($"Runtime error: Variable '{name}' not found.");
        }
    }

    public bool HasVariable(string name)
    {
        return _variables.ContainsKey(name) || (_parentScope != null && _parentScope.HasVariable(name));
    }

    public void SetFunction(string name, FunctionDeclarationExpression function)
    {
        _functions[name] = function;
    }

    public FunctionDeclarationExpression GetFunction(string name)
    {
        if (_functions.TryGetValue(name, out var function))
        {
            return function;
        }
        else if (_parentScope != null)
        {
            return _parentScope.GetFunction(name);
        }
        else
        {
            throw new Exception($"Runtime error: Function '{name}' not found.");
        }
    }

    public bool HasFunction(string name)
    {
        return _functions.ContainsKey(name) || (_parentScope != null && _parentScope.HasFunction(name));
    }
}
