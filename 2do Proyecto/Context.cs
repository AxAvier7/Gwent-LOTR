public class Contexto{
    public Contexto()
    {
        Factions = new List<string>();
        Cards = new List<string>();
    }

    public List<string> Factions{get; set;}
    public List<string> Cards {get; set;}
}