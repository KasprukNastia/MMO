using System;

namespace BranchesAndBoundaries
{
    public class Task
    {
        public int Number { get; }
        public int Duration { get; }
        public int Term { get; }
        public int InitialFineForEarlier { get; }
        public int InitialFineForLater { get; }
        public int StartMoment { get; set; }
        public Task NextTask { get; set; }
        public int EndMoment => StartMoment + Duration;

        public int CurrentFine
        {
            get
            {
                int deviation = Term - (Duration + StartMoment);
                if (deviation > 0)
                    return deviation * InitialFineForEarlier;
                return Math.Abs(deviation) * InitialFineForLater;
            }
        }

        public Task(int number, 
            int duration, 
            int term, 
            int initialFineForEarlier,
            int initialFineForLater)
        {
            Number = number;
            Duration = duration;
            Term = term;
            InitialFineForEarlier = initialFineForEarlier;
            InitialFineForLater = initialFineForLater;
        }

        public Task Clone()
        {
            return this.MemberwiseClone() as Task;
        }
    }
}
