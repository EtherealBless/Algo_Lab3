using System;
using System.IO;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart
{
    public class FileReader
    {
        private Dictionary<int, IExecuterLogic> logicDictionary = new Dictionary<int, IExecuterLogic>
        {
            { 1, new StackLogic() },
            { 2, new QueueListLogic() },
            { 3, new QueueQueueLogic() }
        };

        public FileReader(int numOfQueue)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            string[] lines = File.ReadAllLines(filePath);

            if (logicDictionary.ContainsKey(numOfQueue))
            {
                IExecuterLogic logic = logicDictionary[numOfQueue];
                foreach (string line in lines)
                {
                    logic.ExecuteCommands(line);
                }
            }
            else
            {
                Console.WriteLine("Invalid numOfQueue value.");
            }
        }
    }
}
