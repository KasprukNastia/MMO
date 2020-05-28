using System;
using System.Collections.Generic;

namespace BranchesAndBoundaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int randomTasksCount = random.Next(5, 10);

            List<Task> initialTasks = new List<Task>(randomTasksCount);
            for (int i = 1; i <= randomTasksCount; i++)
            {
                initialTasks.Add(
                    new Task(
                        number: i,
                        duration: random.Next(5, 25),
                        term: random.Next(15, 50),
                        initialFineForEarlier: random.Next(3, 20),
                        initialFineForLater: random.Next(3, 20)));
            }

            var divider = new Divider(initialTasks);
            (Plan bestPlan, float removedPercentage) = divider.GetBestPlan();

            Console.WriteLine();
            Console.WriteLine(bestPlan.ToString());
            Console.WriteLine();
            Console.WriteLine($"Removed percentage: {removedPercentage} %");

            //List<Task> initialTasks = new List<Task>
            //{
            //    new Task(
            //        number: 1,
            //        duration: 12,
            //        term: 26,
            //        initialFineForEarlier: 9,
            //        initialFineForLater: 1),
            //    new Task(
            //        number: 2,
            //        duration: 9,
            //        term: 33,
            //        initialFineForEarlier: 8,
            //        initialFineForLater: 4),
            //    new Task(
            //        number: 3,
            //        duration: 8,
            //        term: 26,
            //        initialFineForEarlier: 5,
            //        initialFineForLater: 3),
            //    new Task(
            //        number: 4,
            //        duration: 8,
            //        term: 37,
            //        initialFineForEarlier: 4,
            //        initialFineForLater: 9)
            //};
        }
    }
}
