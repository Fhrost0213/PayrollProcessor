using System.Collections.Generic;
using System.Linq;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.OvertimeCalculators
{
    public class TimeAndHalfWeeklyOvertimeCalculator : IOvertimeCalculator
    {
        private const decimal _weeklyOvertimeMultiplier = (decimal) 1.5;
        private const decimal _threshold = 40;

        // This calculates for one week
        public PayDto CalculatePay(IEnumerable<Timesheet> timesheets, decimal payRate)
        {
            var hoursWorked = timesheets.Sum(t => t.HoursWorked);

            if (hoursWorked > _threshold)
            {
                var regularHoursWorked = _threshold;
                var overtimeHoursWorked = (hoursWorked - _threshold);
                var regularPay = (_threshold * payRate);
                var overtimePay = (hoursWorked - _threshold) * (payRate * _weeklyOvertimeMultiplier);
                return new PayDto(regularHoursWorked, overtimeHoursWorked, regularPay, overtimePay);
            }
            else
            {
                var regularHoursWorked = hoursWorked;
                var regularPay = (hoursWorked * payRate);
                return new PayDto(regularHoursWorked, 0, regularPay, 0);
            }

            
        }
    }
}
