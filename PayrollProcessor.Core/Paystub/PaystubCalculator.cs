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

        public Entities.Paystub CalculatePaystub(Entities.Paystub paystub, IEnumerable<Timesheet> timesheets)
        {
            // Since I only need to design this to work on 2 week pay periods...
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
