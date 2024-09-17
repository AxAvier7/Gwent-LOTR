using UnityEngine;
using System.Collections.Generic;
using Tookeen;
using aesete;
using ExpressionEvaluator = Bops.ExpressionEvaluator;
using System;
using Lexing;

public class CardProcessor : MonoBehaviour
{
    public UnityEngine.UI.InputField CardCompiler;
    public BaseCard cardBase;

    private Scope scope;

    public void CompileCardInput()
    {
        if (CardCompiler != null && cardBase != null)
        {
            string input = CardCompiler.text;
            if (!string.IsNullOrEmpty(input))
            {
                scope = new Scope(cardBase);

                Lexerr lexerr = new Lexerr(input);       
                List<Token> tokens = lexerr.Tokenize();
                DebugTokens(tokens);
                Parser parser = new Parser(tokens, scope);
                ASTNode ast = parser.Parse();
                ProcessASTToCard(ast);
            }
            else
            {
                Debug.LogWarning("El input del campo CardCompiler está vacío.");
            }
        }
        else
        {
            Debug.LogError("El InputField 'CardCompiler' o el objeto 'BaseCard' no están asignados.");
        }
    }

    private void ProcessASTToCard(ASTNode ast)
    {
        if (ast is CardDeclarationNode cardNode)
        {
            if (Enum.TryParse(cardNode.Type.Type, out CardType cardType))
            {
                scope.SetCardType(cardType);
            }
            else
            {
                throw new Exception($"Tipo de carta inválido: {cardNode.Type.Type}");
            }

            scope.SetCardName(cardNode.Name.Name);

            if (Enum.TryParse(cardNode.Faction.Faction, out FactionType factionType))
            {
                scope.SetCardFaction(factionType);
            }
            else
            {
                throw new Exception($"Facción inválida: {cardNode.Faction.Faction}");
            }

            scope.SetCardPower(EvaluateExpression(cardNode.Power.PowerExpression));
            scope.SetCardRange(cardNode.Range.Ranges);
        }
    }

    private int EvaluateExpression(ExpressionNode expressionNode)
    {
        ExpressionEvaluator evaluator = new ExpressionEvaluator();
        int result = evaluator.EvaluateExpression(expressionNode);
        return result;
    }

    public void DebugTokens(List<Token> tokens)
    {
        foreach (var token in tokens)
        {
            Debug.Log($"Token: Type={token.Type} | Value={token.Value} | L:{token.Line}/C:{token.Column}");
        }
    }
}