using System;
using System.Collections.Generic;

namespace aesete
{
    public abstract class ASTNode
    {
        public abstract void Accept(IASTVisitor visitor);
    }

    #region NodosCartas
    // Nodo para la declaración de una carta
    public class CardDeclarationNode : ASTNode
    {
        public CardTypeNode Type { get; set; }
        public NameNode Name { get; set; }
        public FactionNode Faction { get; set; }
        public PowerNode Power { get; set; }
        public RangeNode Range { get; set; }
        // public List<EffectNode> Effects { get; set; }

        public CardDeclarationNode(CardTypeNode type, NameNode name, FactionNode faction, PowerNode power, RangeNode range /*List<EffectNode> effects*/)
        {
            Type = type;
            Name = name;
            Faction = faction;
            Power = power;
            Range = range;
            // Effects = effects;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para el tipo de carta
    public class CardTypeNode : ASTNode
    {
        public string Type { get; }

        public CardTypeNode(string type)
        {
            Type = type;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para el nombre de la carta
    public class NameNode : ASTNode
    {
        public string Name { get; }

        public NameNode(string name)
        {
            Name = name;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para la facción
    public class FactionNode : ASTNode
    {
        public string Faction { get; }

        public FactionNode(string faction)
        {
            Faction = faction;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para el poder de la carta (soporta expresiones)
    public class PowerNode : ASTNode
    {
        public ExpressionNode PowerExpression { get; }

        public PowerNode(ExpressionNode powerExpression)
        {
            PowerExpression = powerExpression;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para el rango de la carta
    public class RangeNode : ASTNode
    {
        public List<RangeType> Ranges { get; private set; }

        public RangeNode(List<RangeType> ranges)
        {
            Ranges = ranges;
        }
        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }
    #endregion

    #region NodosEfectos
    // // Nodo para la declaración de un efecto
    // public class EffectNode : ASTNode
    // {
    //     public NameNode Name { get; set; }
    //     public EffectParamsNode Params { get; set; }
    //     public ActionNode Action { get; set; }

    //     public EffectNode(NameNode name, EffectParamsNode @params, ActionNode action)
    //     {
    //         Name = name;
    //         Params = @params;
    //         Action = action;
    //     }

    //     public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    // }

    // // Nodo para los parámetros del efecto
    // public class EffectParamsNode : ASTNode
    // {
    //     public Dictionary<string, ASTNode> Parameters { get; set; }

    //     public EffectParamsNode(Dictionary<string, ASTNode> parameters)
    //     {
    //         Parameters = parameters;
    //     }

    //     public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    // }

    // // Nodo para la acción del efecto
    // public class ActionNode : ASTNode
    // {
    //     public string ActionCode { get; }

    //     public ActionNode(string actionCode)
    //     {
    //         ActionCode = actionCode;
    //     }

    //     public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    // }
    #endregion

    #region OtrosNodos
    // Nodo para las expresiones aritméticas (poder)
    public class ExpressionNode : ASTNode
    {
        public string Operator { get; }
        public List<ASTNode> Operands { get; }

        public ExpressionNode(string @operator, List<ASTNode> operands)
        {
            Operator = @operator;
            Operands = operands;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para representar un número en una expresión
    public class NumberNode : ASTNode
    {
        public int Value { get; }

        public NumberNode(int value)
        {
            Value = value;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para representar un operador en una expresión
    public class OperatorNode : ASTNode
    {
        public string Operator { get; }

        public OperatorNode(string @operator)
        {
            Operator = @operator;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para representar una cadena en una expresión
    public class StringNode : ASTNode
    {
        public string Value { get; }

        public StringNode(string value)
        {
            Value = value;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para operaciones de incremento (++)
    public class IncrementNode : ASTNode
    {
        public ASTNode Operand { get; }

        public IncrementNode(ASTNode operand)
        {
            Operand = operand;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    // Nodo para operaciones de decremento (--)
    public class DecrementNode : ASTNode
    {
        public ASTNode Operand { get; }

        public DecrementNode(ASTNode operand)
        {
            Operand = operand;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }
    #endregion

    public interface IASTVisitor
    {
        void Visit(CardDeclarationNode cardDeclaration);
        void Visit(CardTypeNode cardType);
        void Visit(NameNode name);
        void Visit(FactionNode faction);
        void Visit(PowerNode power);
        void Visit(RangeNode range);
        void Visit(ExpressionNode expression);
        void Visit(NumberNode number);   
        void Visit(OperatorNode @operator); 
        void Visit(StringNode str); 
        // void Visit(EffectNode effect);
        // void Visit(EffectParamsNode effectParams);
        // void Visit(ActionNode action);
        void Visit(IncrementNode incrementNode);
        void Visit(DecrementNode decrementNode);
    }
}