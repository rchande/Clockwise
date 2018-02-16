using System;

namespace Clockwise
{
    public class BudgetExceededException : Exception
    {
        public BudgetExceededException(Budget budget) : base(BuildMessage(budget))
        {
        }

        private static string BuildMessage(Budget budget)
        {
            string durationDescription = null;
            if (budget is TimeBudget timeBudget)
            {
                durationDescription = $"{timeBudget.DurationDescription} ";
            }

            return $"Budget {durationDescription}exceeded.{budget.EntriesDescription}";
        }
    }
}
