using System.Collections.Generic;

public class Effect
{
    public string Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
    public int Amount { get; set; }

    public Effect(string name, Dictionary<string, object> parameters, int amount)
    {
        Name = name;
        Parameters = parameters;
        Amount = amount;
    }

    public int GetAmount()
    {
        return Amount;
    }
}
