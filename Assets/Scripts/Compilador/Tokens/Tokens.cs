using System.Collections.Generic;

namespace Tookeen
{
    //Define la ubicacion de un elemento en todo el codigo a traves de la linea y la columna
    public class CodeLocation
    {
        public CodeLocation(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public int Line { get; }
        public int Column { get; }

        public CodeLocation(CodeLocation tookeenLocation)
        {
            Line = tookeenLocation.Line;
            Column = tookeenLocation.Column;
        }
    }

    //Define los tokens que se utilizaran luego en el analisis lexico
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
            { "+", TokenType.Operador },
            { "-", TokenType.Operador },
            { "*", TokenType.Operador },
            { "/", TokenType.Operador },
            { "++", TokenType.MasMas },
            { "--", TokenType.MenosMenos },
            { "^", TokenType.Operador },

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
            { "\"", TokenType.Quote },

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
            { "Melee", TokenType.Range },
            { "Ranged", TokenType.Range },
            { "Siege", TokenType.Range },
            { "Comunidad del Anillo", TokenType.Faction },
            { "Mordor", TokenType.Faction },
            { "None", TokenType.Faction },
            { "Oro", TokenType.Type },
            { "Plata", TokenType.Type },
            { "Lider", TokenType.Type },
            { "Aumento", TokenType.Type },
            { "Clima", TokenType.Type },
        };
    }

    public enum TokenType
    {
        EOF, // Fin del archivo
        EOL, // Fin de línea

        // Tipos
        Number, IDs, Reserved, String, Boolean, Variable,

        // Booleanos
        _true, _false,

        // Ciclos
        If, While, Else, For, Return, Break, Continue,

        // Corchetes
        ParAb, ParCer, CorAb, CorCer, LlaveAb, LlaveCer, Keyword,

        // Operadores
        Mas, Menos, Multiplicacion, Division, Arroba, MinorSign, MajorSign,
        Equal, TwoPoints, Comma, And, Or, MasMas, MenosMenos,
        MasIgual, MenosIgual, MultiplicacionIgual, DivisionIgual, Desigual, Asignacion, TyDollaSign,
        Implicacion, StringConcat, Dot, MajorEqual, MinorEqual, SemiColon, Denial, Pow, Quote,

        // Reservados
        Card, Power, Faction, Range, Effect, CardSharpEffect, Predicate,
        PostAction, Type, Name, Params, Action, Source, Single,
        In, OnActivation, Selector, Amount,

        TypeIdentifier, Function, Context, Targets, Operador,

        Unknown // Otros
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