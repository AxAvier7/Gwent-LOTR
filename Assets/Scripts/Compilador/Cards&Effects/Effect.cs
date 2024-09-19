using System;
using System.Collections.Generic;

public class Effect
{
    public string Name { get; set; }
    public Dictionary<string, (Type, object)> Params { get; set; } = new Dictionary<string, (Type, object)>();
    public Action<List<Card>, Context> Action { get; set; }

    public Effect(string name, Action<List<Card>, Context> action)
    {
        Name = name;
        Action = action;
    }

    public void AddParam(string paramName, Type paramType, object paramValue)
    {
        Params[paramName] = (paramType, paramValue);
    }

    public object GetParam(string paramName)
    {
        return Params.TryGetValue(paramName, out var param) ? param.Item2 : null;
    }

    public Type GetParamType(string paramName)
    {
        return Params.TryGetValue(paramName, out var param) ? param.Item1 : null;
    }
}