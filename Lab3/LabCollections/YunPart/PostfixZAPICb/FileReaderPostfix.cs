using System;
using System.IO;
using Lab3.LabCollections.YunPart;

namespace Lab3.Menus
{
    internal class FileReaderPostfix
    {
        public static void ReadAndCalculate()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\inputPostfix.txt");
            try
            {
                string input = File.ReadAllText(filePath);
                PostfixCalculator calculator = new PostfixCalculator();
                calculator.EvaluatePostfix(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}
