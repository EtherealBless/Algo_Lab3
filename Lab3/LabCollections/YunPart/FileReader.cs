using System;
using System.IO;

namespace Lab3.LabCollections.YunPart
{
    public class FileReader
    {
        public FileReader(int numOfQueue)
        {
           //Запускает старый алгорим и все равно выводит не правильно
           //FileReaderOLD test = new(numOfQueue);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            string[] lines = File.ReadAllLines(filePath);


            if (numOfQueue == 1)
            {
                StackLogic stackLogic = new StackLogic();
                foreach (string line in lines)
                {
                    stackLogic.ExecuteCommands(line);
                }
            }
            else if (numOfQueue == 2)
            {
                QueueListLogic queueListLogic = new QueueListLogic();
                foreach (string line in lines)
                {
                    queueListLogic.ExecuteCommands(line);
                }
            }
            else if (numOfQueue == 3)
            {
                QueueQueueLogic queueQueueLogic = new QueueQueueLogic();
                foreach (string line in lines)
                {
                    queueQueueLogic.ExecuteCommands(line);
                }
            }
        }
    }
}
