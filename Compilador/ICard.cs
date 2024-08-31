    public enum CardFaction
    {
        Mordor,
        ComunidadDelAnillo,
        None
    }

    public enum CardRange
    {
        Melee,
        Ranged,
        Siege
    }

    public interface ICard
    {
        string Name { get; }
        string Type { get; }
        CardFaction Faction { get; }
        CardRange Range { get; }
        int Power { get; }
        List<EfectoDeclarado> Effects { get; }
    }

    public class MyCards : ICard
    {
        public MyCards(string name, string type, CardFaction faction, CardRange range, int power, List<EfectoDeclarado> effects)
        {
            Name = name;
            Type = type;
            Faction = faction;
            Range = range;
            Power = power;
            Effects = effects;
        }

        public string Name { get; }

        public string Type { get; }

        public CardFaction Faction { get; }

        public CardRange Range { get; }

        public int Power { get; }

        public List<EfectoDeclarado> Effects { get; }
    }