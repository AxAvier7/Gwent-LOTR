public class Context
{
    private readonly Dictionary<string, object> _variables = new Dictionary<string, object>();
    private readonly Dictionary<string, FunctionDeclarationExpression> _functions = new Dictionary<string, FunctionDeclarationExpression>();

    public static Context Current { get; } = new Context();

    public void SetVariable(string name, object value) => _variables[name] = value;

    public object GetVariable(string name) =>
        _variables.TryGetValue(name, out var value) ? value : throw new Exception($"Runtime error: Variable '{name}' not found.");

    public void SetFunction(string name, FunctionDeclarationExpression function) => _functions[name] = function;

    public FunctionDeclarationExpression GetFunction(string name) =>
        _functions.TryGetValue(name, out var function) ? function : null;
}