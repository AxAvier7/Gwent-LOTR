public enum TokenType
{
    EOF, //fin del archivo
    EOL, // fin de linea

    //Tipos
    Number,    IDs,    Reserved,
    String, Boolean,

    //Booleanos
    _true, _false,

    //Cycles
    If, While, Else, For,

    //Brackets
    ParAb,    ParCer,    CorAb,    CorCer,
    LlaveAb,    LlaveCer,

    //Operadores
    Mas,    Menos,  Multiplicacion, Division, //+ - * /
    Arroba, MinorSign,  MajorSign,  Equal, //@ < > ==
    TwoPoints,  Comma, And, Or, //: , && ||
    MasMas, MenosMenos, MasIgual, MenosIgual, //++ -- += -=
    MultiplicacionIgual, DivisionIgual,   Desigual,  Asignacion, //*= /= != =
    TyDollaSign, Implicacion, StringConcat, Dot, //$ => @@ .
    MajorEqual, MinorEqual, SemiColon, Denial, //>= <= ; !

    //Reservados
    Card,   Power,  Faction,    Range,
    Effect, CardSharpEffect,
    Predicate, PostAction, Type, Name,
    Params, Action, Source, Single,
    In, OnActivation, Selector,


    Unknown //otros
}

public static Dictionary<string, TokenType> AllTokens = new Dictionary<string, TokenType>
{
    //keywords
    { "card", TokenType.Card },
    { "Name", TokenType.Name },
    { "Type", TokenType.Type },
    { "Faction", TokenType.Faction },
    { "Power", TokenType.Power },
    { "Range", TokenType.Range },
    { "OnActivation", TokenType.OnActivation },
    { "effect", TokenType.Effect },
    { "Effect", TokenType.CardSharpEffect },
    { "Selector", TokenType.Selector },
    { "Postaction", TokenType.PostAction },
    { "Source", TokenType.Source },
    { "Single", TokenType.Single },
    { "Predicate", TokenType.Predicate },
    { "Action", TokenType.Action },
    { "Params", TokenType.Params },
    { "Amount", TokenType.Amount },

    //common ones
    { "if", TokenType.If },
    { "while", TokenType.While },
    { "for", TokenType.For },
    { "else", TokenType.Else },
    { "=>", TokenType.Implicacion },

    //operators
    { "=", TokenType.Asignacion },
    { "+=", TokenType.MasIgual },
    { "-=", TokenType.MenosIgual },
    { "+=", TokenType.MultiplicacionIgual },
    { "-=", TokenType.DivisionIgual },
    { ">", TokenType.MajorSign },
    { "<", TokenType.MinorSign },
    { ">=", TokenType.MajorEqual },
    { "<=", TokenType.MinorEqual },
    { "==", TokenType.Equal },
    { "!=", TokenType.Desigual },
    { "+", TokenType.Mas },
    { "-", TokenType.Menos },
    { "*", TokenType.Multiplicacion },
    { "/", TokenType.Division },
    { "++", TokenType.MasMas },
    { "--", TokenType.MenosMenos },

    //punctuation
    { "{", TokenType.LlaveAb },
    { "}", TokenType.LlaveCer },
    { "[", TokenType.CorAb },
    { "]", TokenType.CorCer },
    { "(", TokenType.ParAb },
    { ")", TokenType.ParCer },
    { ":", TokenType.TwoPoints },
    { ".", TokenType.Dot },
    { ",", TokenType.Comma },
    { ";", TokenType.SemiColon },

    //booleans
    { "true", TokenType._true },
    { "false", TokenType._false },
    { "&&", TokenType.And },
    { "||", TokenType.Or },
    { "!", TokenType.Denial },

    { "@", TokenType.Arroba },
    { "@@", TokenType.StringConcat },
    { "$", TokenType.TyDollaSign },
    };

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
