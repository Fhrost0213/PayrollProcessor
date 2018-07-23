using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using PayrollProcessor.Core.Entities;
using StructureMap.Query;

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

            const decimal ceilingForDailyRegularTime = 8;

            var dailyHourBreakdown = timesheetList.Select(x =>
            {
                var regularHours = x.HoursWorked <= ceilingForDailyRegularTime ? x.HoursWorked : ceilingForDailyRegularTime;
               
                var otHours = x.HoursWorked > ceilingForDailyRegularTime ? x.HoursWorked - ceilingForDailyRegularTime : 0;

                return Tuple.Create(regularHours, otHours);
            });

            var dailyRegular = dailyHourBreakdown.Select(x => x.Item1 * payRate);
            var dailyOT = dailyHourBreakdown.Select(x => x.Item2 * payRate * 1.5m);

            var regularHours1 = timesheetList
                .Where(x => x.HoursWorked <= 8)
                .Select(x => x.HoursWorked * payRate);

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
                overtimePay = overtimeHoursWorked * (payRate * _weeklyOvertimeMultiplier);
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
