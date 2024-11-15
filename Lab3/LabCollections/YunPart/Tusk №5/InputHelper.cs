using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab3.LabCollections
{
    internal static class InputHelper
    {
        internal static void InputList<T>(this QueueQueue<T> queue, string input)
        {
            string[] values = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                queue.Enqueue((T)Convert.ChangeType(value.Trim(), typeof(T), CultureInfo.InvariantCulture));
            }
        }

        internal static T ReadValue<T>()
        {
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input.Trim(), typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
