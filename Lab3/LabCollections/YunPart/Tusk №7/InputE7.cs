using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InputE7
    {
        internal static void ExecuteTask7()
        {
            QueueQueue<int> queue = new QueueQueue<int>();

            // Ввод списка через пробел
            Console.Write("Введите элементы списка через пробел: ");
            string input = Console.ReadLine();
            queue.InputList(input);

            // Ввод значения E
            Console.Write("Введите значение E: ");
            int e = InputHelper.ReadValue<int>();

            // Выполнение задачи 7
            queue.RemoveAllOccurrencesOfElement(e);

            // Вывод списка (для проверки)
            queue.Print();
        }
    }
}
