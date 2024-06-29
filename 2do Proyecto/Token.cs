public class Token
{
    public string Value { get; private set; }
    public TokenType Type { get; private set; }
    public CodeLocation Location { get; private set; }

    public Token(TokenType type, string value, CodeLocation location)
    {
        this.Type = type;
        this.Value = value;
        this.Location = location;
    }

    public override string ToString()
        => string.Format("{0} [{1}]", Type, Value);
}

public struct CodeLocation
{
    public string File;
    public int Line;
    public int Column;
}


public enum TokenType
{
    Unknown,
    Number,
    Text,
    Keyword,
    Identifier,
    Symbol
}

public class TokenValues
{
    protected TokenValues() { }

    public const string Add = "Addition"; // +
    public const string Sub = "Subtract"; // -
    public const string Mul = "Multiplication"; // *
    public const string Div = "Division"; // /

    public const string Igual = "Assign"; // =
    public const string Coma = "ValueSeparator"; // ,
    public const string PuntoComa = "StatementSeparator"; // ;

    public const string ParentAbierto = "OpenBracket"; // (
    public const string ParentCerrado = "ClosedBracket"; // )
    public const string LlaveAbierta = "OpenCurlyBraces"; // {
    public const string LlaveCerrada = "ClosedCurlyBraces"; // }

    public const string Nombre = "Name"; // Nombre
    public const string Description = "Description"; // descripcion
    public const string Poder = "Power"; // power
    public const string Faccion = "Faction"; // Faccion
    public const string Franja = "Frange"; // Franja
    public const string Rango = "Rank"; //Rango
    public const string EsLider = "Lider"; // Leader
}