using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PayrollProcessor.Core;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.Repositories;

namespace PayrollProcessor.Tests
{
    [TestFixture]
    public class PayrollServiceTests
    {
        [Test]
        public void PayrollService_ShouldGetTwoWeeksPayCorrectly_TimeAndHalfCalculatorWithNoOvertime()
        {
            //Arrange
            var date = DateTime.Parse("2018-06-22");

            var timesheetGetRepoMock = new Mock<ITimesheetGetRepository>();
            timesheetGetRepoMock.Setup(x => x.GetTimesheetsForLastTwoWeeks(date))
                .Returns(GetTimesheets());

            var employeeGetRepoMock = new Mock<IEmployeeGetRepository>();
            employeeGetRepoMock.Setup(x => x.Get(1)).Returns(new Employee
            {
                FirstName = "Test",
                HourlyRate = 100,
                State = State.TX,
                LastName = "Test",
                Id = 1
            });

            var sut = new PayrollService(timesheetGetRepoMock.Object, employeeGetRepoMock.Object);

            //Act
            var paystubs = sut.GetPaystubs(date);
            var firstPaystub = paystubs.First();

            //Assert
            Assert.That(firstPaystub.TotalOvertimeHoursWorked == 0);
            Assert.That(firstPaystub.TotalOvertimePay == 0);
            Assert.That(firstPaystub.TotalRegularHoursWorked == 80);
            Assert.That(firstPaystub.TotalRegularPay == 8000);
        }

        private List<Timesheet> GetTimesheets()
        {
            var timesheets = new List<Timesheet>();
            var timesheet = new Timesheet();

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-11"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-12"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 2,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-13"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 3,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-14"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 4,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-15"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-18"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-19"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 2,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-20"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 3,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-21"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 4,
                EmployeeId = 1,
                Date = DateTime.Parse("2018-06-22"),
                HoursWorked = 8
            };
            timesheets.Add(timesheet);

            return timesheets;
        }
    }
}
