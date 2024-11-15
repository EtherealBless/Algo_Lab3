using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InputF
    {
        internal static void ExecuteTask8()
        {
            QueueQueue<int> queue = new QueueQueue<int>();

            // Ввод списка через пробел
            Console.Write("Введите элементы списка через пробел: ");
            string input = Console.ReadLine();
            queue.InputList(input);

            // Ввод значения F
            Console.Write("Введите значение F: ");
            int f = InputHelper.ReadValue<int>();

            // Ввод значения E
            Console.Write("Введите значение E: ");
            int e = InputHelper.ReadValue<int>();

            // Выполнение задачи 8
            queue.InsertBeforeFirstOccurrence(f, e);

            // Вывод списка (для проверки)
            queue.Print();
        }
    }
}
