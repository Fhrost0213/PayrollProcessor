using System;
using System.Collections.Generic;
using NUnit.Framework;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.OvertimeCalculators;
using PayrollProcessor.Core.Paystub;

namespace PayrollProcessor.Tests.Paystub
{
    [TestFixture]
    public class PaystubCalculatorTests
    {
        [Test]
        public void PaystubCalculator_ShouldCalculate_OvertimeCorrectly()
        {
            //Arrange
            var payRate = 100;
            var sut = new PaystubCalculator(new TexasOvertimeCalculator(), payRate);
            var paystub = new Core.Entities.Paystub();
            var timesheets = new List<Timesheet>();

            AddTimesheets(timesheets);

            paystub.StartDate = DateTime.Parse("2018-06-04");
            paystub.EndDate = DateTime.Parse("2018-06-17");

            //Act
            sut.CalculatePaystub(paystub, timesheets);

            //Assert
            Assert.AreEqual(paystub.TotalOvertimeHoursWorked, 8);
            Assert.AreEqual(paystub.TotalOvertimePay, 1200);
            Assert.AreEqual(paystub.TotalRegularHoursWorked, 64);
            Assert.AreEqual(paystub.TotalRegularPay, 6400);
        }

        private void AddTimesheets(ICollection<Timesheet> timesheets)
        {
            var timesheet = new Timesheet();
            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-06"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-09"),
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
