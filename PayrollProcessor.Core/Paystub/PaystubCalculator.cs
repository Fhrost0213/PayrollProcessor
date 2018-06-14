using System.Collections.Generic;
using System.Linq;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.OvertimeCalculators;

namespace PayrollProcessor.Core.Paystub
{
    public class PaystubCalculator
    {
        private readonly IOvertimeCalculator _overtimeCalculator;
        private readonly decimal _payRate;

        public PaystubCalculator(IOvertimeCalculator overtimeCalculator, decimal payRate)
        {
            _overtimeCalculator = overtimeCalculator;
            _payRate = payRate;
        }

        // Shouldn't be messing with inputs, needs to be simple. You told me to calc, I calc.
        public Entities.Paystub CalculatePaystub(Entities.Paystub paystub, IEnumerable<Timesheet> timesheets)
        {
            // IEnumerable below is being ran over twice, we can call ToList() and get it once.
            // If this was an infinite list, you wouldn't want to call that. OOM??

            // This is logic! Get this out of my calculator.
            var hoursWorkedFirstWeek = timesheets
                .Where(t => t.Date >= paystub.StartDate && t.Date <= paystub.StartDate.AddDays(6))
                .Sum(t => t.HoursWorked);
            var hoursWorkedSecondWeek = timesheets
                .Where(t => t.Date >= paystub.StartDate.AddDays(7) && t.Date <= paystub.EndDate)
                .Sum(t => t.HoursWorked);

            Calculate(paystub, hoursWorkedFirstWeek);
            Calculate(paystub, hoursWorkedSecondWeek);

            return paystub;
        }

        // TODO: Return new response object, paystub shouldnt be input
        // This is functional - this shouldn't have state at all. Why is it void?
        // Function should take something and return something
        private void Calculate(Entities.Paystub paystub, decimal hoursWorked)
        {
            if (hoursWorked > 40)
            {
                paystub.TotalRegularHoursWorked += 40;
                paystub.TotalOvertimeHoursWorked += (hoursWorked - 40);
                paystub.TotalRegularPay += (40 * _payRate);
                paystub.TotalOvertimePay += _overtimeCalculator.CalculateOvertime(hoursWorked - 40, _payRate);
            }
            else
            {
                paystub.TotalRegularHoursWorked += hoursWorked;
                paystub.TotalOvertimeHoursWorked += 0;
                paystub.TotalRegularPay += (hoursWorked * _payRate);
                paystub.TotalOvertimePay += 0;
            }
        }
    }
}
