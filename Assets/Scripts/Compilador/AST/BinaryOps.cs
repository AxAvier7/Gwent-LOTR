using System.Collections.Generic;
using aesete;
using UnityEngine;

namespace Bops
{
    public class ExpressionEvaluator : IASTVisitor
    {
        private Stack<int> values = new Stack<int>();
        private Stack<string> strings = new Stack<string>();

        // Método para evaluar expresiones aritméticas
        public int EvaluateExpression(ExpressionNode expression)
        {
            Visit(expression);
            return values.Pop();
        }

        // Método para evaluar expresiones de concatenación de cadenas
        public string EvaluateStringExpression(ExpressionNode expression)
        {
            Visit(expression);
            return strings.Pop();
        }

        // Implementación de IASTVisitor
        public void Visit(CardDeclarationNode cardDeclaration) { }
        public void Visit(CardTypeNode cardType) { }
        public void Visit(NameNode name) { }
        public void Visit(FactionNode faction) { }
        public void Visit(PowerNode power) { }
        public void Visit(RangeNode range) { }

        public void Visit(NumberNode number)
        {
            values.Push(number.Value);
        }

        public void Visit(StringNode stringNode)
        {
            strings.Push(stringNode.Value);
        }

        // Implementación de la lógica para operadores matemáticos
        public void Visit(OperatorNode @operator)
        {
            if (values.Count < 2)
            {
                throw new System.InvalidOperationException("No hay suficientes operandos en la pila para realizar la operación.");
            }

            int right = values.Pop();
            int left = values.Pop();

            int result;
            switch (@operator.Operator)
            {
                case "+":
                    result = left + right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "*":
                    result = left * right;
                    break;
                case "/":
                    if (right == 0)
                        throw new System.DivideByZeroException("División por cero.");
                    result = left / right;
                    break;
                case "^":
                    result = (int)Mathf.Pow(left, right);
                    break;
                default:
                    throw new System.Exception("Operador no soportado: " + @operator.Operator);
            }

            values.Push(result);
        }


        public void Visit(IncrementNode incrementNode)
        {
            incrementNode.Operand.Accept(this);
            int value = values.Pop();
            values.Push(value + 1);
        }

        public void Visit(DecrementNode decrementNode)
        {
            decrementNode.Operand.Accept(this);
            int value = values.Pop();
            values.Push(value - 1);
        }

        public void Visit(ExpressionNode expression)
        {
            foreach (var operand in expression.Operands)
            {
                operand.Accept(this);
            }

            if (!string.IsNullOrEmpty(expression.Operator))
            {
                if (expression.Operator == "@@")
                {
                    string right = strings.Pop();
                    string left = strings.Pop();
                    strings.Push(left + right);
                }
                else
                {
                    Visit(new OperatorNode(expression.Operator));
                }
            }
        }
    }
}
