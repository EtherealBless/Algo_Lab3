using System;
using System.Collections.Generic;
using Lab3.LabCollections.YunPart;

namespace Lab3.Menus
{
    internal class PostfixCalculatorMenu : IMenu
    {
        public Dictionary<int, Action> Commands { get; set; }

        public PostfixCalculatorMenu()
        {
            Commands = new Dictionary<int, Action>()
            {
                {1, EvaluatePostfixExpression},
                {2, EvaluatePostfixFromFile}
            };
        }

        public void PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. Evaluate Postfix Expression");
            Console.WriteLine("2. Evaluate Postfix Expression from File");
            Console.WriteLine(" ");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
        }

        private void EvaluatePostfixExpression()
        {
            Console.WriteLine("Enter the infix expression:");
            string expression = Console.ReadLine();
            string postfixExpression = InfixToPostfixConverter.ConvertToPostfix(expression);
            PostfixCalculator calculator = new PostfixCalculator();
            calculator.EvaluatePostfix(postfixExpression);
        }

        private void EvaluatePostfixFromFile()
        {
            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();
            PostfixCalculator calculator = new PostfixCalculator();
            calculator.ReadAndEvaluateFromFile(filePath);
        }
    }
}
