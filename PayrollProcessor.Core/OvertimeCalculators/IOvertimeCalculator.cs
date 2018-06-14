namespace PayrollProcessor.Core.OvertimeCalculators
{
    public interface IOvertimeCalculator
    {
        decimal OvertimeMultiplier { get; }
        decimal CalculateOvertime(decimal timeWorked, decimal payRate);
    }
}
