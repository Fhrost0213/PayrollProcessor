using System.Collections.Generic;
using System.Linq;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.OvertimeCalculators
{
    public class TimeAndHalfWeeklyOvertimeCalculator : IOvertimeCalculator
    {
        private readonly decimal _weeklyOvertimeMultiplier = (decimal) 1.5;

        // This calculates for one week
        public PayDto CalculatePay(IEnumerable<Timesheet> timesheets, decimal payRate)
        {
            decimal regularHoursWorked = 0;
            decimal overtimeHoursWorked = 0;
            decimal regularPay = 0;
            decimal overtimePay = 0;

            var hoursWorked = timesheets.Sum(t => t.HoursWorked);

            if (hoursWorked > 40)
            {
                regularHoursWorked = 40;
                overtimeHoursWorked = (hoursWorked - 40);
                regularPay = (40 * payRate);
                overtimePay = (hoursWorked - 40) * (payRate * _weeklyOvertimeMultiplier);
            }
            else
            {
                regularHoursWorked = hoursWorked;
                overtimeHoursWorked = 0;
                regularPay = (hoursWorked * payRate);
                overtimePay = 0;
            }

            return new PayDto(regularHoursWorked, overtimeHoursWorked, regularPay, overtimePay);
        }
    }
}
