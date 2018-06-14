namespace PayrollProcessor.Core.OvertimeCalculators
{
    public class TexasOvertimeCalculator : IOvertimeCalculator
    {
        public decimal OvertimeMultiplier => (decimal) 1.5;

        public decimal CalculateOvertime(decimal timeWorked, decimal payRate)
        {
            return timeWorked * (payRate * OvertimeMultiplier);
        }
    }
}
