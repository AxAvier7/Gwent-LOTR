using System.Collections.Generic;
using Tookeen;

namespace Tookeen2
{
    // Clase base para todos los tokens
    public abstract class AstNode
    {
        public CodeLocation Location { get; set; }
    }

    // Nodo para representar el programa
    public class ProgramNode : AstNode
    {
        public List<DeclarationNode> Declarations { get; } = new List<DeclarationNode>();
    }

    // Clase abstracta para todas las declaraciones
    public abstract class DeclarationNode : AstNode { }

    // Para declarar variables
    public class VariableDeclarationNode : DeclarationNode
    {
        public string VariableName { get; set; }
        public string VariableType { get; set; }
        public ExpressionNode InitialValue { get; set; }
    }

    // Para declarar funciones
    public class FunctionDeclarationNode : DeclarationNode
    {
        public string FunctionName { get; set; }
        public List<ParameterNode> Parameters { get; } = new List<ParameterNode>();
        public BlockNode Body { get; set; }
        public string ReturnType { get; set; }
    }

    // Para declarar clases
    public class ClassDeclarationNode : DeclarationNode
    {
        public string ClassName { get; set; }
        public List<VariableDeclarationNode> Fields { get; } = new List<VariableDeclarationNode>();
        public List<FunctionDeclarationNode> Methods { get; } = new List<FunctionDeclarationNode>();
    }

    // Para definir parametros de funciones
    public class ParameterNode : AstNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Para representar bloques de statements
    public class BlockNode : AstNode
    {
        public List<StatementNode> Statements { get; } = new List<StatementNode>();
    }

    // Clase abstracta para todos los statement
    public abstract class StatementNode : AstNode { }

    // Expression statement
    public class ExpressionStatementNode : StatementNode
    {
        public ExpressionNode Expression { get; set; }
    }

    // If statement
    public class IfStatementNode : StatementNode
    {
        public ExpressionNode Condition { get; set; }
        public BlockNode ThenBlock { get; set; }
        public BlockNode ElseBlock { get; set; }
    }

    // While statement
    public class WhileStatementNode : StatementNode
    {
        public ExpressionNode Condition { get; set; }
        public BlockNode Body { get; set; }
    }

    // For statement
    public class ForStatementNode : StatementNode
    {
        public StatementNode Initializer { get; set; }
        public ExpressionNode Condition { get; set; }
        public StatementNode Iterator { get; set; }
        public BlockNode Body { get; set; }
    }

    // Devolver statement
    public class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnValue { get; set; }
    }

    // Clase abstracta para todas las expresiones
    public abstract class ExpressionNode : AstNode { }

    // Expresiones binarias
    public class BinaryExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public string Operator { get; set; }
        public ExpressionNode Right { get; set; }
    }

    // Expresiones unarias
    public class UnaryExpressionNode : ExpressionNode
    {
        public string Operator { get; set; }
        public ExpressionNode Operand { get; set; }
    }

    // Expresiones literales
    public class LiteralExpressionNode : ExpressionNode
    {
        public string Value { get; set; }
    }

    // Expresiones variables
    public class VariableExpressionNode : ExpressionNode
    {
        public string VariableName { get; set; }
    }

    // Llamar expresiones
    public class FunctionCallExpressionNode : ExpressionNode
    {
        public string FunctionName { get; set; }
        public List<ExpressionNode> Arguments { get; } = new List<ExpressionNode>();
    }

    // Asignar expresiones
    public class AssignmentExpressionNode : ExpressionNode
    {
        public string VariableName { get; set; }
        public ExpressionNode Value { get; set; }
    }

    // Expresiones condicionales (operadores ternarios)
    public class ConditionalExpressionNode : ExpressionNode
    {
        public ExpressionNode Condition { get; set; }
        public ExpressionNode TrueExpression { get; set; }
        public ExpressionNode FalseExpression { get; set; }
    }
}