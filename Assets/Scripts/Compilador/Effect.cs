using System;
using System.Collections.Generic;
using Tookeen;
using Tookeen2;
using Read;
using Bops;
using Cont;

public class EffectParam
{
    public string Name { get; }
    public ParamType Type { get; }

    public EffectParam(string name, ParamType type)
    {
        Name = name;
        Type = type;
    }
}

public class CardEffect
{
    public string Name { get; }
    public Dictionary<string, EffectParam> Params { get; }
    public Action<List<object>, Context> Action { get; }

    public CardEffect(string name, Dictionary<string, EffectParam> parameters, Action<List<object>, Context> action)
    {
        Name = name;
        Params = parameters;
        Action = action;
    }

    public void Execute(List<object> targets, Context context)
    {
        Action(targets, context);
    }
}