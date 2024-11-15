
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab3.LabCollections;
using Lab3.LabCollections.YunPart.PolishNotation.Clases;

namespace Lab3.LabCollections.YunPart.PolishNotation
{
    public class Calculator
    {
        private static List<Operation> _existOperation;
        private Stack<object> list = new Stack<object>();
        private static Operation FindOperation(string name)
        {
            if (_existOperation == null)
            {
                Type parent = typeof(Operation);
                IEnumerable<Assembly> allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                IEnumerable<Type> types = allAssemblies.SelectMany(x => x.GetTypes());
                IEnumerable<Type> inherTypes = types.Where(t => parent.IsAssignableFrom(t) && !t.IsAbstract).ToList();

                _existOperation = inherTypes.Select(type => (Operation)Activator.CreateInstance(type)).ToList();
            }
            return _existOperation.FirstOrDefault(op => op.Name.Equals(name));
        }

        public double Resulting(string input, double x)
        {
            List<Token> postPars = Parsing(input);
            List<Token> rpn = PolishChange(postPars);
            List<Token> rpn2 = rpn.ToList();
            Console.WriteLine("ЗАЛУПА ЗАУЛУПА ЗАЛУПА " + rpn.ToList());
            double absoluteFinale = Calculating(rpn, x);
            return absoluteFinale;
        }

        private List<Token> Parsing(string input)
        {
            List<Token> finals = new();
            string number = "";
            string opers = "";
            foreach (char tokens in input)
            {
                if (tokens.Equals('('))
                {
                    Clearing(number, opers, finals, tokens);
                    opers = "";
                    Parenthesis par = new();
                    par.bracket = true;
                    finals.Add(par);
                    number = "";
                }
                else if (tokens.Equals(')'))
                {
                    Clearing(number, opers, finals, tokens);
                    opers = "";
                    Parenthesis par = new();
                    par.bracket = false;
                    finals.Add(par);
                    number = "";
                }
                else if (tokens.Equals(';'))
                {
                    Clearing(number, opers, finals, tokens);
                    opers = "";
                    Other obj = new();
                    finals.Add(obj);
                    number = "";
                }
                else if (tokens.Equals('x'))
                {
                    Clearing(number, opers, finals, tokens);
                    opers = "";
                    Variable digits = new Variable(tokens);
                    finals.Add(digits);
                    number = "";
                }
                else if (char.IsLetter(tokens))
                {
                    opers += tokens;
                }
                else if (char.IsDigit(tokens) ^ tokens.Equals(','))
                {
                    Clearing("", opers, finals, tokens);
                    opers = "";
                    number += tokens;
                }
                else
                {
                    Clearing(number, "", finals, tokens);
                    finals.Add(FindOperation(tokens.ToString()));
                    number = "";
                    opers = "";
                }
            }
            Clearing(number, opers, finals, ' ');
            return finals;
        }

        private void Clearing(string number, string opers, List<Token> finals, char tokens)
        {
            if (number != "")
            {
                Number digits = new Number(tokens);
                digits.Numbering = double.Parse(number);
                finals.Add(digits);
            }
            if (opers != "")
            {
                finals.Add(FindOperation(opers));
            }
        }

        private List<Token> PolishChange(List<Token> postPars)
        {
            Stack<Token> buffer = new Stack<Token>();
            List<Token> finals = new List<Token>();
            foreach (Token tokens in postPars)
            {
                if (tokens is Operation)
                {
                    if (buffer.IsEmpty() || !(buffer.Top() is Operation))
                    {
                        buffer.Push(tokens);
                        continue;
                    }

                    var op = tokens as Operation;
                    var op1 = buffer.Top() as Operation;

                    if (!buffer.IsEmpty() && op1.Priority >= op.Priority)
                    {
                        finals.Add(buffer.Pop());
                    }
                    buffer.Push(tokens);
                }
                else if (tokens is Parenthesis)
                {
                    if (((Parenthesis)tokens).bracket)
                    {
                        buffer.Push((Parenthesis)tokens);
                    }
                    else
                    {
                        while (!buffer.IsEmpty() && !(buffer.Top() is Parenthesis))
                        {
                            finals.Add(buffer.Pop());
                        }
                        buffer.Pop();
                    }
                }
                else if (tokens is Number or Variable)
                {
                    finals.Add(tokens);
                }
                else
                    continue;
            }
            while (buffer.Top() != null)
            {

                finals.Add(buffer.Pop());
            }
            return finals;
        }

        private double Calculating(List<Token> rpn, double x)
        {
            Stack<double> buffer = new Stack<double>();
            foreach (Token tokens in rpn)
            {
                if (tokens is Number num)
                {
                    buffer.Push(num.Numbering);
                }
                else if (tokens is Variable)
                {
                    buffer.Push(x);
                }
                else if (tokens is Operation)
                {
                    Operation op = (Operation)tokens;

                    double[] args = new double[op.ArgsCount];
                    for (int i = op.ArgsCount - 1; i >= 0; i--)
                    {
                        if (buffer.IsEmpty())
                            args[i] = double.PositiveInfinity;
                        else
                            args[i] = buffer.Pop();
                    }
                    double result = ExecuteDouble(op, args);
                    buffer.Push(result);
                }
            }
            return buffer.Top();
        }

        private double ExecuteDouble(Operation op, double[] args)
        {
            Number[] numbers = new Number[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                numbers[i] = new Number(args[i]);
            }
            Number resultNumber = op.Execute(numbers);
            return resultNumber.Numbering;
        }
    }
}
