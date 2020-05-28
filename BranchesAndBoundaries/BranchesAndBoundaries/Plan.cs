using System.Collections.Generic;
using System.Linq;

namespace BranchesAndBoundaries
{
    /// <summary>
    /// План
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// Завдання, які входять до плану
        /// </summary>
        public LinkedList<Task> Tasks { get; }

        /// <summary>
        /// Поточний штраф для плану
        /// </summary>
        public int CurrentFine => Tasks.Sum(t => t.CurrentFine);

        public Plan(Task appendedTask, LinkedList<Task> currentPlan = null)
        {
            if (currentPlan == null)
                currentPlan = new LinkedList<Task>();

            if(appendedTask != null)
                currentPlan.AddLast(appendedTask);

            LinkedListNode<Task> currentTask = currentPlan.First;
            int currentDuration = 0;
            while(currentTask.Next != null)
            {
                currentDuration += currentTask.Value.Duration;
                currentTask.Next.Value.StartMoment = currentDuration;

                currentTask = currentTask.Next;
            }

            Tasks = currentPlan;
        }

        public Plan Clone()
        {
            LinkedList<Task> cloneTaskList = new LinkedList<Task>();
            foreach(Task task in Tasks)
            {
                cloneTaskList.AddLast(task.Clone());
            }

            return new Plan(null, cloneTaskList);
        }

        public override string ToString()
        {
            return $"Fine: {CurrentFine}\n" +
                $"Tasks: {string.Join(" -> ", Tasks.Select(t => t.Number))}";
        }
    }
}
