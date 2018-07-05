using System.Collections.Generic;
using System.Linq;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.OvertimeCalculators
{
    public class TimeAndQuarterDailyOvertimeCalculator : IOvertimeCalculator
    {
        private const decimal _weeklyOvertimeMultiplier = (decimal) 1.5;
        private const decimal _dailyOvertimeMultiplier = (decimal) 1.25;

        // This calculates for one week
        public PayDto CalculatePay(IEnumerable<Timesheet> timesheets, decimal payRate)
        {
            var timesheetList = timesheets.ToList();

            decimal regularHoursWorked;
            decimal regularPay;
            decimal overtimePay;
            decimal overtimeHoursWorked = 0;
            decimal dailyOvertimePay = 0;

            foreach (var timesheet in timesheetList)
            {
                if (timesheet.HoursWorked <= 8) continue;
                var overtimeHours = timesheet.HoursWorked - 8;
                dailyOvertimePay += overtimeHours * (payRate * _dailyOvertimeMultiplier);
                overtimeHoursWorked += overtimeHours;
            }

            var hoursWorked = timesheetList.Sum(t => t.HoursWorked);

            if (hoursWorked > 40)
            {
                regularHoursWorked = 40;
                overtimeHoursWorked += (hoursWorked - 40);
                regularPay = (40 * payRate);
                overtimePay = (hoursWorked - 40) * (payRate * _weeklyOvertimeMultiplier);
            }
            else
            {
                regularHoursWorked = hoursWorked;
                regularPay = (hoursWorked * payRate);
                overtimePay = 0;
            }

            overtimePay += dailyOvertimePay;

            return new PayDto(regularHoursWorked, overtimeHoursWorked, regularPay, overtimePay);
        }
    }
}
