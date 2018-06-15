using PayrollProcessor.Core.OvertimeCalculators;

namespace PayrollProcessor.Core
{
    public class OvertimeCalculatorFactory
    {
        public IOvertimeCalculator GetCalculator(State employeeState)
        {
            switch (employeeState)
            {
                case State.CA:
                    return new TimeAndHalfOvertimeCalculator();
                default:
                    return new TimeAndHalfOvertimeCalculator();
            }
        }
    }
}
