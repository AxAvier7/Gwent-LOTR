using System;
using System.Collections.Generic;

public class Scope
{
    public BaseCard CurrentCard { get; private set; }

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
}
