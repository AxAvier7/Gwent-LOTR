using System.Collections.Generic;
using Tookeen;
using aesete;
using ExpressionEvaluator = Bops.ExpressionEvaluator;
using System;
using Debug = UnityEngine.Debug;

public class Parser
{
    readonly List<Token> tokens;
    private int position;
    readonly Scope scope;

    public Parser(List<Token> tokens, Scope scope)
    {
        this.tokens = tokens;
        this.position = 0;
        this.scope = scope;
    }

    public ASTNode Parse()
    {
        if (Check(TokenType.Card))
        {
            Consume(TokenType.Card);
            return ParseCard();
        }
        if (Check(TokenType.Effect))
        {
            Consume(TokenType.Effect);
            // return ParseEffect();
        }

        throw new Exception($"Se esperaba una definición de carta o de efecto, pero se encontró: {tokens[position].Type} en la posición {position}.");
    }

    // private ASTNode ParseEffect()
    // {
    //     Consume(TokenType.LlaveAb);
    //     NameNode effectNameNode = null;
    //     EffectParamsNode effectParamsNode = null;
    //     ActionNode = null;

    //     bool expectComma = false;
    //     while(!Check(TokenType.LlaveCer))
    //     {
    //         if (expectComma && !Match(TokenType.Comma))
    //         {
    //             throw new Exception($"Se esperaba una coma en L:{tokens[position].Line}/C:{tokens[position].Column}, pero se encontró: {tokens[position].Type}");
    //         }
    //         if(Match(TokenType.Name))
    //         {
    //             Consume(TokenType.TwoPoints);
    //             string firstPart = Consume(TokenType.String).Value;
    //             if (Match(TokenType.StringConcat))
    //             {
    //                 string secondPart = Consume(TokenType.String).Value;
    //                 string name = firstPart + " " + secondPart;
    //                 scope.SetEffectName(name);
    //                 effectNameNode = new EffectNameNode(name);
    //             }
    //             else if (Match(TokenType.Arroba))
    //             {
    //                 string secondPart = Consume(TokenType.String).Value;
    //                 string name = firstPart + secondPart;
    //                 scope.SetEffectName(name);
    //                 effectNameNode = new EffectNameNode(name);
    //             }
    //             else
    //             {
    //                 scope.SetEffectName(firstPart);
    //                 effectEffectNode = new EffectNameNode(firstPart);
    //             }
    //             expectComma = true;            
    //         }
    //         else if(Match(TokenType.Params))
    //         {

    //         }
    //     }
    // }

    private ASTNode ParseCard()
    {
        Consume(TokenType.LlaveAb);

        CardTypeNode typeNode = null;
        NameNode nameNode = null;
        FactionNode factionNode = null;
        PowerNode powerNode = null;
        RangeNode rangeNode = null;

        bool expectComma = false;

        while (!Check(TokenType.LlaveCer))
        {
            if (expectComma && !Match(TokenType.Comma))
            {
                throw new Exception($"Se esperaba una coma en L:{tokens[position].Line}/C:{tokens[position].Column}, pero se encontró: {tokens[position].Type}");
            }

            if (Match(TokenType.Type))
            {
                Consume(TokenType.TwoPoints);
                CardType cardType = ParseTypeValue();
                typeNode = new CardTypeNode(cardType.ToString());
                scope.SetCardType(cardType);
                expectComma = true;
            }
            else if (Match(TokenType.Name))
            {
                Consume(TokenType.TwoPoints);
                string name = Consume(TokenType.String).Value;

                while (Match(TokenType.StringConcat))
                {
                    string nextPart = Consume(TokenType.String).Value;
                    name += " " + nextPart;
                }

                while (Match(TokenType.Arroba))
                {
                    string nextPart = Consume(TokenType.String).Value;
                    name += nextPart;
                }
                scope.SetCardName(name);
                nameNode = new NameNode(name);

                expectComma = true;
            }
            else if (Match(TokenType.Faction))
            {
                Consume(TokenType.TwoPoints);
                FactionType factionType = ParseFactionValue();
                factionNode = new FactionNode(factionType.ToString());
                scope.SetCardFaction(factionType);
                expectComma = true;
            }
            else if (Match(TokenType.Power))
            {
                ParsePower();
                expectComma = true;
            }
            else if (Match(TokenType.Range))
            {
                Consume(TokenType.TwoPoints);
                List<RangeType> ranges = ParseRangeValues();
                rangeNode = new RangeNode(ranges);
                scope.SetCardRange(ranges);
            }
            else
            {
                throw new Exception($"Se encontró un token inesperado ({tokens[position].Type}) en la posición L:{tokens[position].Line}/C:{tokens[position].Column}");
            }
        }

        Consume(TokenType.LlaveCer);
        return new CardDeclarationNode(typeNode, nameNode, factionNode, powerNode, rangeNode);
    }

    #region MetodosparaparsearCartas
    private CardType ParseTypeValue()
    {
        Token token = Consume(TokenType.Type);
        switch (token.Value)
        {
            case "Oro": return CardType.Oro;
            case "Plata": return CardType.Plata;
            case "Lider":
                Debug.LogError("Ya existe un lider en cada faccion. Se le asigno tipo Plata a la carta");
                return CardType.Plata;
            case "Aumento": return CardType.Aumento;
            case "Clima": return CardType.Clima;
            default:
                throw new Exception("Tipo de carta inválido: " + token.Value);
        }
    }

    private FactionType ParseFactionValue()
    {
        Token token = Consume(TokenType.Faction);
        switch (token.Value)
        {
            case "Comunidad del Anillo": return FactionType.CDA;
            case "Mordor": return FactionType.Mordor;
            case "None": return FactionType.None;
            default:
                throw new Exception("Facción inválida: " + token.Value);
        }
    }

    private List<RangeType> ParseRangeValues()
    {
        Consume(TokenType.CorAb);
        List<RangeType> ranges = new List<RangeType>();

        while (!Check(TokenType.CorCer))
        {
            Token token = Consume(TokenType.Range);
            switch (token.Value)
            {
                case "Melee": ranges.Add(RangeType.Melee); break;
                case "Ranged": ranges.Add(RangeType.Ranged); break;
                case "Siege": ranges.Add(RangeType.Siege); break;
                default:
                    throw new Exception("Valor de rango inválido: " + token.Value);
            }

            if (Match(TokenType.Comma))
                continue;
        }

        Consume(TokenType.CorCer);
        return ranges;
    }



    private ExpressionNode ParseExpression()
    {
        Stack<ASTNode> operands = new Stack<ASTNode>();
        Stack<Operators> operators = new Stack<Operators>();
        operands.Push(new NumberNode(int.Parse(Consume(TokenType.Number).Value)));

        while (Check(TokenType.Operador))
        {
            var currentOperator = ParseOperator(Consume(TokenType.Operador).Value);
            if (!Check(TokenType.Number))
            {
                throw new Exception($"Se esperaba un número después del operador en C:{tokens[position].Column}/L:{tokens[position].Line}, pero se encontró: {tokens[position].Type}");
            }

            operands.Push(new NumberNode(int.Parse(Consume(TokenType.Number).Value)));
            operators.Push(currentOperator);
        }

        if (operators.Count == 0)
        {
            return new ExpressionNode("Number", new List<ASTNode> { operands.Pop() });
        }

        while (operators.Count > 0)
        {
            var op = operators.Pop();
            var right = operands.Pop();
            var left = operands.Pop();
            operands.Push(new ExpressionNode(op.ToString(), new List<ASTNode> { left, right }));
        }

        return (ExpressionNode)operands.Pop();
    }

    private NumberNode ParseNumberExpression()
    {
        if (!Check(TokenType.Number))
        {
            throw new Exception($"Se esperaba un número en L:{tokens[position].Line}/C:{tokens[position].Column}, pero se encontró: {tokens[position].Type}");
        }

        return new NumberNode(int.Parse(Consume(TokenType.Number).Value));
    }

    private Operators ParseOperator(string value)
    {
        return value switch
        {
            "+" => Operators.Addition,
            "-" => Operators.Substraction,
            "*" => Operators.Multiplication,
            "/" => Operators.Division,
            "^" => Operators.Pow,
            _ => throw new Exception("Operador inválido: " + value),
        };
    }

    private void ParsePower()
    {
        Consume(TokenType.TwoPoints);

        if (!Check(TokenType.Number))
        {
            throw new Exception($"Se esperaba un número después de 'Power:', pero se encontró: {tokens[position].Type}");
        }

        var firstNumberToken = Consume(TokenType.Number);
        int firstNumber = int.Parse(firstNumberToken.Value);

        if (Check(TokenType.Operador))
        {
            var powerExpressionNode = ParseExpressionStartingWith(firstNumber);

            int evaluatedPower = EvaluateExpression(powerExpressionNode);

            scope.SetCardPower(evaluatedPower);
        }
        else
        {
            scope.SetCardPower(firstNumber);
        }
    }

    private ExpressionNode ParseExpressionStartingWith(int firstNumber)
    {
        Stack<ASTNode> operands = new Stack<ASTNode>();
        Stack<Operators> operators = new Stack<Operators>();

        operands.Push(new NumberNode(firstNumber));

        while (Check(TokenType.Operador))
        {
            var currentOperator = ParseOperator(Consume(TokenType.Operador).Value);

            if (!Check(TokenType.Number))
            {
                throw new Exception($"Se esperaba un número después del operador en L:{tokens[position].Line}/C:{tokens[position].Column}, pero se encontró: {tokens[position].Type}");
            }

            operands.Push(new NumberNode(int.Parse(Consume(TokenType.Number).Value)));

            operators.Push(currentOperator);
        }

        if (operators.Count == 0)
        {
            return new ExpressionNode("Number", new List<ASTNode> { operands.Pop() });
        }

        while (operators.Count > 0)
        {
            var op = operators.Pop();
            var right = operands.Pop();
            var left = operands.Pop();
            operands.Push(new ExpressionNode(op.ToString(), new List<ASTNode> { left, right }));
        }

        return (ExpressionNode)operands.Pop();
    }

    #endregion MetodosparaparsearCartas

    private int EvaluateExpression(ExpressionNode expressionNode)
    {
        ExpressionEvaluator evaluator = new ExpressionEvaluator();
        return evaluator.EvaluateExpression(expressionNode);
    }

    #region Auxiliares

    private Token Consume(TokenType expectedType)
    {
        if (Check(expectedType))
        {
            return tokens[position++];
        }

        throw new Exception($"Se esperaba el token {expectedType} en la posición L:{tokens[position].Line}/C:{tokens[position].Column}, pero se encontró: {tokens[position].Type}.");
    }

    private bool Match(TokenType type)
    {
        if (Check(type))
        {
            position++;
            return true;
        }
        return false;
    }

    private bool Check(TokenType type)
    {
        return position < tokens.Count && tokens[position].Type == type;
    }
}

public enum CardType
{
    Oro,
    Plata,
    Aumento,
    Clima
}

public enum FactionType
{
    CDA,
    Mordor,
    None
}

public enum RangeType
{
    Melee,
    Ranged,
    Siege
}



public enum Operators {None, Addition, Substraction, Multiplication, Division, Pow}
#endregion Auxiliares