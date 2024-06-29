public class Scope{
    public Scope()
    {
        Factions = new List<string>();
    }

    public Scope? Parent {get; set;}

    public Scope CreateChild(){
        Scope child = new Scope();
        child.Parent = this;

        return child;
    }
}