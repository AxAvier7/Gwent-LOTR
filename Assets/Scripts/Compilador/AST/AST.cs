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
        public int Amount { get; }
        public List<ActivationNode> ActivationNodes { get; set; }

        public CardDeclarationNode(CardTypeNode type, NameNode name, FactionNode faction, PowerNode power, RangeNode range, List<ActivationNode> activationNodes, int amount)
        {
            Type = type;
            Name = name;
            Faction = faction;
            Power = power;
            Range = range;
            Amount = amount;
            ActivationNodes = activationNodes;
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
    public class ActionNode : ASTNode
    {
        public List<ASTNode> Statements { get; }

        public ActionNode(List<ASTNode> statements)
        {
            Statements = statements;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class EffectNode : ASTNode
    {
        public string EffectName { get; }
        public Dictionary<string, object> Parameters { get; }

        public EffectNode(string effectName, Dictionary<string, object> parameters)
        {
            EffectName = effectName;
            Parameters = parameters;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class ParameterNode : ASTNode
    {
        public string Name { get; }
        public object Value { get; }

        public ParameterNode(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }


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

    public class IfStatementNode : ASTNode
    {
        public ExpressionNode Condition { get; }
        public List<ASTNode> TrueStatements { get; }
        public List<ASTNode> FalseStatements { get; }

        public IfStatementNode(ExpressionNode condition, List<ASTNode> trueStatements, List<ASTNode> falseStatements = null)
        {
            Condition = condition;
            TrueStatements = trueStatements;
            FalseStatements = falseStatements ?? new List<ASTNode>();
        }
        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class ForLoopNode : ASTNode
    {
        public string VariableName { get; }
        public ExpressionNode Start { get; }
        public ExpressionNode End { get; }
        public List<ASTNode> Body { get; }

        public ForLoopNode(string variableName, ExpressionNode start, ExpressionNode end, List<ASTNode> body)
        {
            VariableName = variableName;
            Start = start;
            End = end;
            Body = body;
        }
        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class ForeachLoopNode : ASTNode
    {
        public string VariableName { get; }
        public ExpressionNode Collection { get; }
        public List<ASTNode> Body { get; }

        public ForeachLoopNode(string variableName, ExpressionNode collection, List<ASTNode> body)
        {
            VariableName = variableName;
            Collection = collection;
            Body = body;
        }
        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class BinaryExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; }
        public ExpressionNode Right { get; }
        public string Operator { get; }

        public BinaryExpressionNode(ExpressionNode left, string operatorSymbol, ExpressionNode right)
            : base(operatorSymbol, new List<ASTNode> { left, right })
        {
            Left = left;
            Right = right;
            Operator = operatorSymbol;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class ActivationNode : ASTNode
    {
        public EffectNode Effect { get; }
        public SelectorNode Selector { get; }
        public ActionNode PostAction { get; }

        public ActivationNode(EffectNode effect, SelectorNode selector, ActionNode postAction)
        {
            Effect = effect;
            Selector = selector;
            PostAction = postAction;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class SelectorNode : ASTNode
    {
        public string Source { get; }
        public bool Single { get; }
        public PredicateNode Predicate { get; }

        public SelectorNode(string source, bool single, PredicateNode predicate)
        {
            Source = source;
            Single = single;
            Predicate = predicate;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }

    public class PredicateNode : ASTNode
    {
        public string Expression { get; }

        public PredicateNode(string expression)
        {
            Expression = expression;
        }

        public override void Accept(IASTVisitor visitor) => visitor.Visit(this);
    }
    
    public class PostActionNode : ActionNode
    {
        public string Type { get; }
        public SelectorNode Selector { get; }

        public PostActionNode(string type, SelectorNode selector) : base(new List<ASTNode>())
        {
            Type = type;
            Selector = selector;
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
        void Visit(BinaryExpressionNode binaryExpression);
        void Visit(NumberNode number);   
        void Visit(OperatorNode @operator); 
        void Visit(StringNode str); 
        void Visit(IfStatementNode node);
        void Visit(ForLoopNode node);
        void Visit(ForeachLoopNode node);
        void Visit(IncrementNode incrementNode);
        void Visit(DecrementNode decrementNode);
        void Visit(ActionNode actionNode);
        void Visit(EffectNode effectNode);
        void Visit(ParameterNode parameterNode);
        void Visit(ActivationNode activationNode);
        void Visit(SelectorNode selectorNode);
        void Visit(PredicateNode predicateNode);
        void Visit(PostActionNode postActionNode);
    }
}