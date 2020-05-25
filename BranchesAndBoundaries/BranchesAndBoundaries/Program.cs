using System.Collections.Generic;

namespace BranchesAndBoundaries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> initialTasks = new List<Task>
            {
                new Task(
                    number: 1,
                    duration: 12,
                    term: 26,
                    initialFineForEarlier: 9,
                    initialFineForLater: 1),
                new Task(
                    number: 2,
                    duration: 9,
                    term: 33,
                    initialFineForEarlier: 8,
                    initialFineForLater: 4),
                new Task(
                    number: 3,
                    duration: 8,
                    term: 26,
                    initialFineForEarlier: 5,
                    initialFineForLater: 3),
                new Task(
                    number: 4,
                    duration: 8,
                    term: 37,
                    initialFineForEarlier: 4,
                    initialFineForLater: 9)
            };

            var divider = new Divider(initialTasks);
            Plan bestPlan = divider.GetBestPlan();
        }
    }
}
