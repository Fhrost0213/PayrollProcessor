namespace PayrollProcessor.Core.OvertimeCalculators
{
    public class OvertimeCalculatorFactory
    {
        public IOvertimeCalculator GetCalculator(State employeeState)
        {
            switch (employeeState)
            {
                case State.CA:
                    return new TimeAndHalfWeeklyOvertimeCalculator();
                default:
                    return new TimeAndHalfWeeklyOvertimeCalculator();
            }
        }
    }
}
