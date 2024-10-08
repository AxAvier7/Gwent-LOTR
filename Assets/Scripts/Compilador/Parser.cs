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
        if (Check(TokenType.CardSharpEffect))
        {
            Consume(TokenType.CardSharpEffect);
            return ParseEffect();
        }

        throw new Exception($"Se esperaba una definición de carta o de efecto, pero se encontró: {tokens[position].Type} en la posición {position}.");
    }

    private ASTNode ParseCard()
    {
        Consume(TokenType.LlaveAb);

        CardTypeNode typeNode = null;
        NameNode nameNode = null;
        FactionNode factionNode = null;
        PowerNode powerNode = null;
        RangeNode rangeNode = null;
        string effectName = null;
        int amount = 0;
        List<ActivationNode> activationNodes = new List<ActivationNode>();

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
            else if (Match(TokenType.Effect))
            {
                Consume(TokenType.TwoPoints);
                effectName = Consume(TokenType.String).Value;
            }
            else if (Match(TokenType.Amount))
            {
                Consume(TokenType.TwoPoints);
                amount = int.Parse(Consume(TokenType.Number).Value);
                Debug.LogError(amount);
            }
            else if (Match(TokenType.OnActivation))
            {
                Consume(TokenType.TwoPoints);
                activationNodes = ParseOnActivation();
                expectComma = true;
            }
            else
            {
                throw new Exception($"Se encontró un token inesperado ({tokens[position].Type}) en la posición L:{tokens[position].Line}/C:{tokens[position].Column}");
            }
        }

        Consume(TokenType.LlaveCer);

        return new CardDeclarationNode(typeNode, nameNode, factionNode, powerNode, rangeNode, activationNodes, amount);    
    }

    private EffectNode ParseEffect()
    {
        Consume(TokenType.LlaveAb);
        
        string effectName = string.Empty;
        int amount = 0;
        Dictionary<string, object> parameters = new Dictionary<string, object>();

        while (!Check(TokenType.LlaveCer))
        {
            if (Match(TokenType.Name))
            {
                Consume(TokenType.TwoPoints);
                effectName = Consume(TokenType.String).Value;
                Consume(TokenType.Comma);
            }
            else if(Match(TokenType.Amount))
            {
                Consume(TokenType.TwoPoints);
                if(Check(TokenType.Number))
                {
                    amount = int.Parse(Consume(TokenType.Number).Value);
                }
                else throw new Exception($"Se esperaba un numero en en la posición L:{tokens[position].Line}/C:{tokens[position].Column}");
                Consume(TokenType.Comma);
            }
            else if (Match(TokenType.Params))
            {
                Consume(TokenType.TwoPoints);
                Consume(TokenType.LlaveAb);
                parameters = ParseEffectParameters();
                Consume(TokenType.LlaveCer);
            }
            else if (Match(TokenType.Action))
            {
                var actionNode = ParseEffectAction(parameters);
            }
            else
            {
                throw new Exception($"Token inesperado al parsear el efecto en L:{tokens[position].Line}/C:{tokens[position].Column}");
            }
        }

        Effect effect = new Effect(effectName, parameters, amount);        
        Consume(TokenType.LlaveCer);
        return new EffectNode(effectName, parameters);
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

    #region MetodosparaparsearEfectos
    private Dictionary<string, object> ParseEffectParameters()
    {
        var parameters = new Dictionary<string, object>();
            
        while (true)
        {
            if (Check(TokenType.LlaveCer))
            {
                Consume(TokenType.LlaveCer);
                break;
            }
            string paramName = Consume(TokenType.Amount).Value;
            Consume(TokenType.TwoPoints);
            object paramValue;

            if (Match(TokenType.Number))
            {
                paramValue = int.Parse(Consume(TokenType.Number).Value);
            }
            else if (Match(TokenType.IDs))
            {
                paramValue = Consume(TokenType.IDs).Value;
            }
            else if (Match(TokenType.String))
            {
                paramValue = Consume(TokenType.String).Value;
            }
            else if (Match(TokenType.Boolean))
            {
                paramValue = Consume(TokenType.Boolean).Value.ToLower() == "true"; 
            }
            else
            {
                throw new Exception($"Tipo de parámetro no reconocido en L:{tokens[position].Line}/C:{tokens[position].Column}");
            }
           parameters[paramName] = paramValue;

            if (Check(TokenType.Comma))                    
                Consume(TokenType.Comma);
            
        }            
        Consume(TokenType.LlaveCer);
        return parameters;
    }

    private ActionNode ParseEffectAction(Dictionary<string, object> parameters)
    {
        if (!Match(TokenType.Action))
        {
            throw new Exception($"Se esperaba el token 'Action' en L:{tokens[position].Line}/C:{tokens[position].Column}");
        }

        Consume(TokenType.LlaveAb);

        List<ASTNode> actionStatements = new List<ASTNode>();

        while (!Check(TokenType.LlaveCer))
        {
            var statementNode = ParseActionStatement(parameters);
            actionStatements.Add(statementNode);

            if (Check(TokenType.Comma))
                Consume(TokenType.Comma);
        }

        Consume(TokenType.LlaveCer);

        return new ActionNode(actionStatements);
    }

    private ASTNode ParseActionStatement(Dictionary<string, object> parameters)
    {
        if (Match(TokenType.IDs))
        {
            string identifier = Consume(TokenType.IDs).Value;
            if (parameters.ContainsKey(identifier))
            {
                return new ParameterNode(identifier, parameters[identifier]);
            }
        }

        throw new Exception($"Declaración de acción no válida en L:{tokens[position].Line}/C:{tokens[position].Column}");
    }

    private List<ActivationNode> ParseOnActivation()
    {
        List<ActivationNode> activationNodes = new List<ActivationNode>();
        Consume(TokenType.CorAb);

        while (!Check(TokenType.CorCer))
        {
            Consume(TokenType.LlaveAb);

            EffectNode effectNode = null;
            SelectorNode selectorNode = null;
            PostActionNode postActionNode = null;

            while (!Check(TokenType.LlaveCer))
            {
                if (Match(TokenType.Effect))
                {
                    Consume(TokenType.TwoPoints);
                    effectNode = ParseEffect();
                }
                else if (Match(TokenType.Selector))
                {
                    Consume(TokenType.TwoPoints);
                    selectorNode = ParseSelector();
                }
                else if (Match(TokenType.PostAction))
                {
                    Consume(TokenType.TwoPoints);
                    postActionNode = ParsePostAction();
                }
                else
                {
                    throw new Exception($"Token inesperado al parsear OnActivation en L:{tokens[position].Line}/C:{tokens[position].Column}");
                }
            }

            Consume(TokenType.LlaveCer);
            activationNodes.Add(new ActivationNode(effectNode, selectorNode, postActionNode));

            if (Check(TokenType.Comma))
            {
                Consume(TokenType.Comma);
            }
        }

        Consume(TokenType.CorCer);
        return activationNodes;
    }

    private SelectorNode ParseSelector()
    {
        Consume(TokenType.LlaveAb);
        string source = null;
        bool single = false;
        PredicateNode predicateNode = null;

        while (!Check(TokenType.LlaveCer))
        {
            if (Match(TokenType.Source))
            {
                Consume(TokenType.TwoPoints);
                source = Consume(TokenType.String).Value;
            }
            else if (Match(TokenType.Single))
            {
                Consume(TokenType.TwoPoints);
                if(Match(TokenType._true))
                    single = Consume(TokenType.Boolean).Value.ToLower() == "true";
                else if(Match(TokenType._false))
                    single = Consume(TokenType.Boolean).Value.ToLower() == "false";
                Consume(TokenType.Comma);
break;
            }
            else if (Match(TokenType.Predicate))
            {
                Consume(TokenType.TwoPoints);
                predicateNode = ParsePredicate();
            }            
            else if (Check(TokenType.Comma))
            {
                Consume(TokenType.Comma);
            }
            else
            {
                throw new Exception($"Token inesperado al parsear Selector en L:{tokens[position].Line}/C:{tokens[position].Column}");
            }

        }

        Consume(TokenType.LlaveCer);
        return new SelectorNode(source, single, predicateNode);
    }

    private PredicateNode ParsePredicate()
    {
        Consume(TokenType.ParAb);
        string predicateExpression = ""; 

        while (!Check(TokenType.ParCer))
        {
            predicateExpression += ConsumeAny().Value;
        }

        Consume(TokenType.ParCer);
        return new PredicateNode(predicateExpression);
    }

    private PostActionNode ParsePostAction()
    {
        Consume(TokenType.LlaveAb);
        string type = null;
        SelectorNode selectorNode = null;

        while (!Check(TokenType.LlaveCer))
        {
            if (Match(TokenType.Type))
            {
                Consume(TokenType.TwoPoints);
                type = Consume(TokenType.String).Value;
            }
            else if (Match(TokenType.Selector))
            {
                Consume(TokenType.TwoPoints);
                selectorNode = ParseSelector();
            }
            else
            {
                throw new Exception($"Token inesperado al parsear PostAction en L:{tokens[position].Line}/C:{tokens[position].Column}");
            }
        }

        Consume(TokenType.LlaveCer);
        return new PostActionNode(type, selectorNode);
    }


    #endregion

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

        private Comparadores ParseComparisonOperator(string value)
    {
        return value switch
        {
            ">" => Comparadores.Mayor,
            "<" => Comparadores.Menor,
            "==" => Comparadores.Igual,
            "!=" => Comparadores.Diferente,
            ">=" => Comparadores.MayorIgual,
            "<=" => Comparadores.MenorIgual,
            _ => throw new Exception("Comparador inválido: " + value),
        };
    }

    private int EvaluateExpression(ExpressionNode expressionNode)
    {
        ExpressionEvaluator evaluator = new ExpressionEvaluator();
        return evaluator.EvaluateExpression(expressionNode);
    }

    private Token ConsumeAny()
    {
        return tokens[position++];
    }

}


public enum CardType{   Oro,    Plata,  Aumento,    Clima   }
public enum FactionType{    CDA,    Mordor, None    }
public enum RangeType{  Melee,  Ranged, Siege   }
public enum Operators { None, Addition, Substraction, Multiplication, Division, Pow }
public enum Comparadores { None, Mayor, Menor, Igual, Diferente, MayorIgual, MenorIgual }
#endregion Auxiliares