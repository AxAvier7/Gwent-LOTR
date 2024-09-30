using System;
using System.Collections.Generic;
using aesete;
using UnityEngine;

namespace Bops
{
    public class ExpressionEvaluator : IASTVisitor
    {
        private Stack<int> values = new Stack<int>();
        private Stack<string> strings = new Stack<string>();
        // private Stack<EffectNode> effects = new Stack<EffectNode>();

        // Método para evaluar expresiones aritméticas
        public int EvaluateExpression(ExpressionNode expression)
        {
            Visit(expression);
            if (values.Count == 0)
                throw new InvalidOperationException("El stack de valores esta vacio");
            return values.Pop();
        }

        // Método para evaluar expresiones de concatenación de cadenas
        public string EvaluateStringExpression(ExpressionNode expression)
        {
            Visit(expression);
                if (strings.Count == 0)
                    throw new InvalidOperationException("EL stack de strings esta vacio");
            return strings.Pop();
        }

        // Método para evaluar efectos
        // public EffectNode EvaluateEffect(EffectNode effect)
        // {
        //     Visit(effect);
        //     if (effects.Count == 0)
        //         throw new InvalidOperationException("El stack de efectos está vacío");
        //     return effects.Pop();
        // }

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

        public void Visit(OperatorNode @operator)
        {
            if (values.Count < 2)
            {
                throw new InvalidOperationException("No hay suficientes operandos en la pila para realizar la operación.");
            }

            int right = values.Pop();
            int left = values.Pop();

            int result;
            switch (@operator.Operator)
            {
                case "Addition":
                    result = left + right;
                    break;
                case "Substraction":
                    result = left - right;
                    break;
                case "Multiplication":
                    result = left * right;
                    break;
                case "Division":
                    if (right == 0)
                        throw new DivideByZeroException("División por cero.");
                    result = left / right;
                    break;
                case "Pow":
                    result = (int)Mathf.Pow(left, right);
                    break;
                default:
                    Debug.Log($"{@operator.Operator}");
                    throw new Exception("Operador no soportado: " + @operator.Operator);
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
                    if (strings.Count < 2)
                        throw new InvalidOperationException("No hay suficientes cadenas para concatenar");
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

        // public void Visit(EffectNode effect)
        // {
        //     effects.Push(effect);
        //     Debug.Log($"Efecto: {effect.Name}");

        //     foreach (var param in effect.Params)
        //     {
        //         Visit(param);
        //     }
        // }

        // // Visita para el nodo EffectParamsNode
        // public void Visit(EffectParamsNode effectParams)
        // {
        //     foreach (var param in effectParams.Parameters)
        //     {
        //         Debug.Log($"Parámetro: {param.Key}, Valor: {param.Value}");
        //         param.Value.Accept(this);
        //     }
        // }

        // // Visita para el nodo ActionNode
        // public void Visit(ActionNode action)
        // {
        //     Debug.Log("Ejecutando acción...");
        //     action.Action?.Invoke();
        // }
    }
}