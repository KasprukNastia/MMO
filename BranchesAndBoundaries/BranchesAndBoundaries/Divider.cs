using System.Collections.Generic;
using System.Linq;

namespace BranchesAndBoundaries
{
    public class Divider
    {
        private IReadOnlyList<Task> _tasks;
        private List<Plan> _currentPlans;
        private Plan Record => _currentPlans.FirstOrDefault(
            plan => plan.Tasks.Count == _tasks.Count && 
            plan.CurrentFine == _currentPlans.Where(p => p.Tasks.Count == _tasks.Count).Min(p => p.CurrentFine));

        public Divider(List<Task> tasks)
        {
            _tasks = tasks;
            _currentPlans = new List<Plan>();
        }

        public Plan GetBestPlan()
        {
            foreach(Task task in _tasks)
            {
                _currentPlans.Add(new Plan(task.Clone()));
            }

            Plan bestPlan = null;
            List<int> bestPlanTaskNumbers = null;
            while (_currentPlans.Count != 1 || 
                Record == null || 
                !_currentPlans.All(p => p.Tasks.Count == _tasks.Count && p.CurrentFine == Record.CurrentFine))
            {
                if (Record != null)
                {
                    _currentPlans.RemoveAll(p => p.CurrentFine > Record.CurrentFine ||
                        (p.CurrentFine == Record.CurrentFine && p.Tasks.Count < _tasks.Count));
                }                

                bestPlan = _currentPlans.First(
                    plan => plan.CurrentFine == _currentPlans.Min(p => p.CurrentFine));
                bestPlanTaskNumbers = bestPlan.Tasks.Select(t => t.Number).ToList();
                foreach (Task task in _tasks.Where(t => !bestPlanTaskNumbers.Any(n => n == t.Number)))
                {
                    _currentPlans.Add(new Plan(task.Clone(), bestPlan.Clone().Tasks));
                }

                _currentPlans.Remove(bestPlan);
            }

            return _currentPlans.First();
        }
    }
}
