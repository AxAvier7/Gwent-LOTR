using System;
using System.Collections.Generic;
using UnityEngine;

public class Scope
{
    public BaseCard CurrentCard { get; private set; }
    private string effectName;
    private Dictionary<string, string> effectParams = new Dictionary<string, string>();
    private string effectAction;

    public Scope(BaseCard card)
    {
        CurrentCard = card;
    }

    public void SetCardType(CardType cardType)
    {
        CurrentCard.Type = cardType.ToString();
    }

    public void SetCardName(string name)
    {
        CurrentCard.Name = name;
    }

    public void SetCardFaction(FactionType factionType)
    {
        CurrentCard.Faction = factionType.ToString();
    }

    public void SetCardPower(int power)
    {
        CurrentCard.Power = power;
    }

    public void SetCardRange(List<RangeType> ranges)
    {
        CurrentCard.Range = ranges.ConvertAll(r => r.ToString());
    }

    public CardType GetCardType()
    {
        return Enum.TryParse(CurrentCard.Type, out CardType cardType) ? cardType : default;
    }

    public string GetCardName()
    {
        return CurrentCard.Name;
    }

    public FactionType GetCardFaction()
    {
        return Enum.TryParse(CurrentCard.Faction, out FactionType factionType) ? factionType : default;
    }

    public int GetCardPower()
    {
        return CurrentCard.Power;
    }

    public List<RangeType> GetCardRange()
    {
        return CurrentCard.Range.ConvertAll(r => Enum.TryParse(r, out RangeType rangeType) ? rangeType : default);
    }

    public void SetEffectName(string name)
    {
        effectName = name;
        Debug.Log($"Nombre del efecto almacenado en scope: {name}");
    }

    public void AddEffectParam(string paramName, string paramType)
    {
        effectParams[paramName] = paramType;
        Debug.Log($"Parámetro agregado al scope: {paramName} de tipo {paramType}");
    }

    public void SetEffectAction(string action)
    {
        effectAction = action;
        Debug.Log($"Acción del efecto almacenada en scope: {action}");
    }

    public string GetEffectName() => effectName;

    public Dictionary<string, string> GetEffectParams() => effectParams;

    public string GetEffectAction() => effectAction;
}