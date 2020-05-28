using System;
using System.Text;

namespace BranchesAndBoundaries
{
    /// <summary>
    /// Завдання
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Номер завдання
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Тривалість виконання
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Директивний строк виконання
        /// </summary>
        public int Term { get; }

        /// <summary>
        /// Штраф за виконання раніше директивного строку
        /// </summary>
        public int InitialFineForEarlier { get; }

        /// <summary>
        /// Штраф за виконання пізніше директивного строку
        /// </summary>
        public int InitialFineForLater { get; }

        /// <summary>
        /// Момент початку виконання завдання
        /// </summary>
        public int StartMoment { get; set; }

        /// <summary>
        /// Момент закінчення виконання завдання
        /// </summary>
        public int EndMoment => StartMoment + Duration;

        /// <summary>
        /// Поточний штраф
        /// </summary>
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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Number: {Number}");
            stringBuilder.AppendLine($"Duration: {Duration}");
            stringBuilder.AppendLine($"Term: {Term}");
            stringBuilder.AppendLine($"Fine for earlier: {InitialFineForEarlier}");
            stringBuilder.AppendLine($"Fine for later: {InitialFineForLater}");
            stringBuilder.AppendLine($"Start moment: {StartMoment}");
            stringBuilder.AppendLine($"Curent fine: {CurrentFine}");

            return stringBuilder.ToString();
        }
    }
}
