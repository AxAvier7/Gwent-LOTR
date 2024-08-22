public enum TokenType
{
    EOF, //fin del archivo
    EOL, // fin de linea

    Number, //numero
    IDs, //Esta y Reserved son para que cuando revise la lista
    Reserved, // de Keywords decida que tipo de Token es
    String, //string de los de siempre
    StringCont, // Para cadenas comunes
    StringCorch, // Para cadenas entre corchetes

    Mas, //+
    Menos, //-
    Multiplicacion, //*
    Division, // /
    ParAb, // (
    ParCer, // )
    CorAb, // [
    CorCer, // ]
    LlaveAb, // {
    LlaveCer, // }
    Arroba, // @
    MinorSign, // <
    MajorSign, // >
    EqualSign, // =
    TwoPoints, //:
    Comma, // ,

    Card, //Carta
    Power, //Poder
    Faction, //Faccion
    Range, //Rango de ataque

    Unknown //otro
}

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }
    public int Line { get; }
    public int Column { get; }

    public Token(TokenType type, string value, int line, int column)
    {
        Type = type;
        Value = value;
        Line = line;
        Column = column;
    }

    public override string ToString() => $"Tipo: {Type}, Value: '{Value}', Linea: {Line}, Columna: {Column}";
}
