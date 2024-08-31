namespace Tookeen
{
    public class CodeLocation
    {
        public int Line { get; }
        public int Column { get; }

        public CodeLocation(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString() => $"Line: {Line}, Column: {Column}";
    }
    
    public abstract class Expression<T>
    {
        public abstract ExpressionType Return { get; }
        public abstract CodeLocation Location { get; set; }
        public abstract bool RevSemantica(out List<string> errors);
        public abstract bool SemanticRevision(out string error);
        public abstract T Interpret();
        public abstract override string ToString();

         public class CodeLocation
        {
            public CodeLocation(int line, int column)
            {
                Line = line;
                Column = column;
            }

            public int Line { get; }
            public int Column { get; }
        }
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
            Value = type.ToString();;
            Line = line;
            Column = column;
        }

        public override string ToString() => $"Tipo: {Type}, Value: '{Value}', Linea: {Line}, Columna: {Column}";

        public static Dictionary<string, TokenType> AllTokens = new Dictionary<string, TokenType>
        {
            //Keywords
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

            //Ciclos, condiciones
            { "if", TokenType.If },
            { "while", TokenType.While },
            { "for", TokenType.For },
            { "else", TokenType.Else },
            { "=>", TokenType.Implicacion },

            //Operadores
            { "=", TokenType.Asignacion },
            { "+=", TokenType.MasIgual },
            { "-=", TokenType.MenosIgual },
            { "*=", TokenType.MultiplicacionIgual },
            { "/=", TokenType.DivisionIgual },
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
            { "^", TokenType.Pow },

            //Puntuacion
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

            //Booleanos
            { "true", TokenType._true },
            { "false", TokenType._false },
            { "&&", TokenType.And },
            { "||", TokenType.Or },
            { "!", TokenType.Denial },

            //Others
            { "@", TokenType.Arroba },
            { "@@", TokenType.StringConcat },
            { "$", TokenType.TyDollaSign },

            //Extra Stuff
            { "Melee", TokenType.Range_Melee },
            { "Ranged", TokenType.Range_Ranged },
            { "Siege", TokenType.Range_Siege },
            { "Comunidad del Anillo", TokenType.Faction_CDA },
            { "Mordor", TokenType.Faction_Mordor },
            { "None", TokenType.Faction_None },
            { "Oro", TokenType.Type_Oro },
            { "Plata", TokenType.Type_Plata },
            { "Lider", TokenType.Type_Lider },
            { "Aumento", TokenType.Type_Aumento },
            { "Clima", TokenType.Type_Clima },
        };
    }

    public enum TokenType
    {
        EOF, //fin del archivo
        EOL, // fin de linea

        //Tipos
        Number,    IDs,    Reserved,
        String, Boolean, Variable,

        //Booleanos
        _true, _false,

        //Cycles
        If, While, Else, For,
        Return, Break, Continue,

        //Brackets
        ParAb,    ParCer,    CorAb,    CorCer,
        LlaveAb,    LlaveCer, Keyword,

        //Operadores
        Mas,    Menos,  Multiplicacion, Division, //+ - * /
        Arroba, MinorSign,  MajorSign,  Equal, //@ < > ==
        TwoPoints,  Comma, And, Or, //: , && ||
        MasMas, MenosMenos, MasIgual, MenosIgual, //++ -- += -=
        MultiplicacionIgual, DivisionIgual,   Desigual,  Asignacion, //*= /= != =
        TyDollaSign, Implicacion, StringConcat, Dot, //$ => @@ .
        MajorEqual, MinorEqual, SemiColon, Denial, //>= <= ; !
        Pow, //^

        //Reservados
        Card,   Power,  Faction,    Range,
        Effect, CardSharpEffect,
        Predicate, PostAction, Type, Name,
        Params, Action, Source, Single,
        In, OnActivation, Selector, Amount,

        //Extras
        Range_Melee, Range_Ranged, Range_Siege,
        Faction_CDA, Faction_Mordor, Faction_None,
        Type_Oro, Type_Plata, Type_Lider, Type_Aumento, Type_Clima,
        TypeIdentifier, Function,

        Unknown //otros
    }

    public enum ExpressionType
    {
        Binary, Unary,  Literal,
        Conditional,    Loop, ForLoop,
        FunctionCall,   Assignment, Boolean,
        Number, Void,   Function,   Null,
        LogicalAnd, LogicalOr,
        Continue, Break, Return
    }

}