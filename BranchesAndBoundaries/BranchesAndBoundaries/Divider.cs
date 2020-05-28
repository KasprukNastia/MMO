using System.Collections.Generic;
using System.Linq;

namespace BranchesAndBoundaries
{
    public class Divider
    {
        private IReadOnlyList<Task> _tasks;
        private List<Plan> _currentPlans;
        private Plan _record;

        public Divider(List<Task> tasks)
        {
            _tasks = tasks;
            _currentPlans = new List<Plan>();
        }

        public (Plan, float) GetBestPlan()
        {
            foreach(Task task in _tasks)
            {
                _currentPlans.Add(new Plan(task.Clone()));
            }

            Plan bestPlan = null;
            List<int> bestPlanTaskNumbers = null;
            int allPlansCount = _currentPlans.Count;
            int removedPlansCount = 0;
            int currentMinFine;
            List<Plan> recordCandidates;
            while (!_currentPlans.All(p => p.Tasks.Count == _tasks.Count && p.CurrentFine == _record.CurrentFine))
            {
                currentMinFine = _currentPlans.Min(p => p.CurrentFine);
                recordCandidates = _currentPlans.Where(plan => plan.Tasks.Count == _tasks.Count).ToList();
                _record = recordCandidates.FirstOrDefault(c => c.CurrentFine == recordCandidates.Min(rc => rc.CurrentFine));
                if (_record != null)
                {
                    removedPlansCount += _currentPlans.RemoveAll(p => p.CurrentFine > _record.CurrentFine ||
                        (p.CurrentFine == _record.CurrentFine && p.Tasks.Count < _tasks.Count));
                }                

                bestPlan = _currentPlans.FirstOrDefault(
                    plan => plan.CurrentFine == currentMinFine && plan.Tasks.Count < _tasks.Count);

                if (bestPlan == null)
                    continue;

                bestPlanTaskNumbers = bestPlan.Tasks.Select(t => t.Number).ToList();
                foreach (Task task in _tasks.Where(t => !bestPlanTaskNumbers.Any(n => n == t.Number)))
                {
                    _currentPlans.Add(new Plan(task.Clone(), bestPlan.Clone().Tasks));
                    allPlansCount++;
                }

                if(_currentPlans.Count != 1)
                    _currentPlans.Remove(bestPlan);
            }

            return (_currentPlans.First(), removedPlansCount * 100 / allPlansCount);
        }
    }
}
