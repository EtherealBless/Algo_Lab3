using System;
using System.Collections.Generic;
using System.IO;
using Lab3.LabCollections;

namespace Lab3.LabCollections.YunPart
{
    public class PostfixCalculator
    {
        private Stack<double> stack;

        public PostfixCalculator()
        {
            stack = new Stack<double>();
        }

        public void EvaluatePostfix(string expression)
        {
            string[] tokens = expression.Split(' ');

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double result = 0;
                    switch (token)
                    {
                        case "+":
                            result = stack.Pop() + stack.Pop();
                            break;
                        case "-":
                            result = -stack.Pop() + stack.Pop();
                            break;
                        case "*":
                            result = stack.Pop() * stack.Pop();
                            break;
                        case "/":
                            result = 1 / stack.Pop() * stack.Pop();
                            break;
                        case "^":
                            double baseVal = stack.Pop();
                            double exponent = stack.Pop();
                            result = Math.Pow(baseVal, exponent);
                            break;
                        case "l":
                            result = Math.Log(stack.Pop());
                            break;
                        case "c":
                            result = Math.Cos(stack.Pop());
                            break;
                        case "s":
                            result = Math.Sin(stack.Pop());
                            break;
                        case "q":
                            result = Math.Sqrt(stack.Pop());
                            break;
                        default:
                            throw new InvalidOperationException($"Unknown operator: {token}");
                    }
                    stack.Push(result);
                }
            }

            if (stack.IsEmpty())
            {
                Console.WriteLine("Stack is empty. No result.");
            }
            else
            {
                
                Console.WriteLine("Result: " + stack.Pop());
            }
        }

        public void ReadAndEvaluateFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string expression = File.ReadAllText(filePath);
                string postfixExpression = InfixToPostfixConverter.ConvertToPostfix(expression);
                EvaluatePostfix(postfixExpression);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
