using System;
using System.IO;
using Lab3.LabCollections.YunPart.PolishNotation;

namespace Lab3.Menus
{
    internal class PostfixFileReader
    {
        public static void ReadAndCalculate()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\inputPostfix.txt");
            try
            {
                string input = File.ReadAllText(filePath);
                Console.WriteLine("Введите значение переменной x:");
                double x = double.Parse(Console.ReadLine());

                Calculator calculator = new Calculator();
                double result = calculator.Resulting(input, x);

                Console.WriteLine($"Результат выражения \"{input}\" при x = {x} равен {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}
