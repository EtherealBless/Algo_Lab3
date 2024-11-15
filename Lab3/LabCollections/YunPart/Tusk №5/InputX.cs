using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InputX
    {
        internal static void ExecuteTask5()
        {
            QueueQueue<int> queue = new QueueQueue<int>();

            // Ввод списка через пробел
            Console.Write("Введите элементы списка через пробел: ");
            string input = Console.ReadLine();
            queue.InputList(input);

            // Ввод значения X
            Console.Write("Введите значение X: ");
            int x = InputHelper.ReadValue<int>();

            // Выполнение задачи 5
            queue.InsertListAfterFirstOccurrence(x);

            // Вывод списка (для проверки)
            queue.Print();
        }
    }
}
