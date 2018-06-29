using System;
using System.Collections.Generic;
using NUnit.Framework;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.OvertimeCalculators;

namespace PayrollProcessor.Tests.OvertimeCalculators
{
    [TestFixture]
    public class TimeAndQuarterDailyOvertimeCalculatorTests
    {
        [Test]
        public void TimeAndQuarterDailyOvertimeCalculator_ShouldCalculateOvertimeCorrectly()
        {
            var payRate = 100;
            var sut = new TimeAndQuarterDailyOvertimeCalculator();
            var timesheets = new List<Timesheet>();

            AddTimesheets(timesheets);
            
            //Act
            var dto = sut.CalculatePay(timesheets, payRate);

            //Assert
            Assert.AreEqual(dto.OvertimeHoursWorked, 40);
            Assert.AreEqual(dto.OvertimePay, 5500);
            Assert.AreEqual(dto.RegularHoursWorked, 40);
            Assert.AreEqual(dto.RegularPay, 4000);
        }

        private void AddTimesheets(ICollection<Timesheet> timesheets)
        {
            var timesheet = new Timesheet();

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-10"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-11"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 2,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-12"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 3,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-13"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 4,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-14"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);
        }
    }
}
