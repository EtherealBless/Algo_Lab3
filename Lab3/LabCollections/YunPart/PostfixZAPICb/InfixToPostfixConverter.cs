using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.LabCollections.YunPart
{
    public class InfixToPostfixConverter
    {
        private static readonly Dictionary<string, int> OperatorPrecedence = new Dictionary<string, int>
        {
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2},
            {"^", 3},
            {"l", 4}, // ln
            {"c", 4}, // cos
            {"s", 4}, // sin
            {"q", 4}, // sqrt
            {"(", 0}, // Добавляем скобки
            {")", 0}  // Добавляем скобки
        };

        public static string ConvertToPostfix(string infixExpression)
        {
            // Замена длинных строк функций на специальные символы
            infixExpression = infixExpression.Replace("ln", "l").Replace("cos", "c").Replace("sin", "s").Replace("sqrt", "q");

            Stack<string> operatorStack = new Stack<string>();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < infixExpression.Length; i++)
            {
                char token = infixExpression[i];

                if (char.IsWhiteSpace(token))
                {
                    continue; // Игнорирование пробелов и табуляций
                }
                else if (char.IsDigit(token) || token == '.')
                {
                    output.Append(token);
                    while (i + 1 < infixExpression.Length && (char.IsDigit(infixExpression[i + 1]) || infixExpression[i + 1] == '.'))
                    {
                        output.Append(infixExpression[++i]);
                    }
                    output.Append(' ');
                }
                else if (token == '(')
                {
                    operatorStack.Push(token.ToString());
                }
                else if (token == ')')
                {
                    while (operatorStack.Top() != "(")
                    {
                        output.Append(operatorStack.Pop()).Append(' ');
                    }
                    operatorStack.Pop();
                }
                else if (OperatorPrecedence.ContainsKey(token.ToString()))
                {
                    while (operatorStack.Top() != null && OperatorPrecedence[operatorStack.Top()] >= OperatorPrecedence[token.ToString()])
                    {
                        output.Append(operatorStack.Pop()).Append(' ');
                    }
                    operatorStack.Push(token.ToString());
                }
                else
                {
                    throw new InvalidOperationException($"Unknown token: {token}");
                }
            }

            while (operatorStack.Top() != null)
            {
                output.Append(operatorStack.Pop()).Append(' ');
            }

            return output.ToString().Trim();
        }
    }
}
