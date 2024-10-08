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

        // Método para evaluar expresiones aritméticas
        public int EvaluateExpression(ExpressionNode expression)
        {
            Visit(expression);
            if (values.Count == 0)
                throw new InvalidOperationException("El stack de valores está vacío");
            return values.Pop();
        }

        // Método para evaluar expresiones de concatenación de cadenas
        public string EvaluateStringExpression(ExpressionNode expression)
        {
            Visit(expression);
            if (strings.Count == 0)
                throw new InvalidOperationException("El stack de cadenas está vacío");
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
                case "Equal":
                    result = left == right ? 1 : 0;
                    break;
                case "NotEqual":
                    result = left != right ? 1 : 0;
                    break;
                case "LessThan":
                    result = left < right ? 1 : 0;
                    break;
                case "GreaterThan":
                    result = left > right ? 1 : 0;
                    break;
                case "LessThanOrEqual":
                    result = left <= right ? 1 : 0;
                    break;
                case "GreaterThanOrEqual":
                    result = left >= right ? 1 : 0;
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

        public void Visit(IfStatementNode ifStatement)
        {
            bool conditionResult = EvaluateCondition(ifStatement.Condition);
            if (conditionResult)
            {
                foreach (var statement in ifStatement.TrueStatements)
                {
                    statement.Accept(this);
                }
            }
            else
            {
                foreach (var statement in ifStatement.FalseStatements)
                {
                    statement.Accept(this);
                }
            }
        }

        public void Visit(ForLoopNode forLoop)
        {
            int start = EvaluateExpression(forLoop.Start);
            int end = EvaluateExpression(forLoop.End);
            for (int i = start; i < end; i++)
            {
                foreach (var statement in forLoop.Body)
                {
                    statement.Accept(this);
                }
            }
        }

        public void Visit(ForeachLoopNode foreachLoop)
        {
            var collection = EvaluateCollection(foreachLoop.Collection);
            foreach (var item in collection)
            {
                foreach (var statement in foreachLoop.Body)
                {
                    statement.Accept(this);
                }
            }
        }


        public void Visit(BinaryExpressionNode binaryExpression)
        {
            binaryExpression.Left.Accept(this);
            binaryExpression.Right.Accept(this);
        }

        private IEnumerable<object> EvaluateCollection(ExpressionNode collectionNode)
        {
            return new List<object> { 1, 2, 3 };
        }

        private bool EvaluateCondition(ExpressionNode condition)
        {
            if (condition is BinaryExpressionNode binaryNode)
            {
                var left = EvaluateExpression(binaryNode.Left);
                var right = EvaluateExpression(binaryNode.Right);

                switch (binaryNode.Operator)
                {
                    case "&&":
                        return left != 0 && right != 0;
                    case "||":
                        return left != 0 || right != 0;
                    case "==":
                        return left == right;
                    case "!=":
                        return left != right;
                    case "LessThan":
                        return left < right;
                    case "GreaterThan":
                        return left > right;
                    case "LessThanOrEqual":
                        return left <= right;
                    case "GreaterThanOrEqual":
                        return left >= right;
                }
            }
            return false;
        }

        // Método para visitar ActionNode
    public void Visit(ActionNode actionNode)
    {
        foreach (var statement in actionNode.Statements)
        {
            statement.Accept(this);
        }
    }

    // Método para visitar EffectNode
    public void Visit(EffectNode effectNode)
    {
        Debug.Log($"Ejecutando efecto: {effectNode.EffectName}");
        foreach (var param in effectNode.Parameters)
        {
            Debug.Log($"Parámetro: {param.Key} = {param.Value}");
        }
    }

    public void Visit(ParameterNode parameterNode)
    {
        if (parameterNode.Value is int intValue)
        {
            values.Push(intValue);
        }
        else if (parameterNode.Value is string stringValue)
        {
            strings.Push(stringValue);
        }
        else
        {
            throw new Exception($"Tipo de parámetro no soportado: {parameterNode.Value.GetType()}");
        }
    }

    public void Visit(ActivationNode activationNode)
    {
        activationNode.Effect.Accept(this);
        activationNode.Selector?.Accept(this);
        activationNode.PostAction?.Accept(this);
       }

    public void Visit(SelectorNode selectorNode)
        {
            Debug.Log($"Seleccionando desde: {selectorNode.Source}, Selección única: {selectorNode.Single}");
            if (selectorNode.Predicate != null)
            {
                selectorNode.Predicate.Accept(this);
            }
        }

        public void Visit(PredicateNode predicateNode)
        {
            Debug.Log($"Evaluando predicado: {predicateNode.Expression}");
        }

        public void Visit(PostActionNode postActionNode)
        {
            Debug.Log($"Ejecutando acción posterior: {postActionNode.Type}");
                        postActionNode.Selector?.Accept(this);
        }
    }
}