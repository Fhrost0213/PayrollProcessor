using System;
using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public class TimesheetRepository
    {
        public Timesheet Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Timesheet> GetTimesheetsForLastTwoWeeks(DateTime date)
        {
            // TODO: Add implementation
            var timesheets = new List<Timesheet>();

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

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-06"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-09"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 1,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-11"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 2,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-12"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 3,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-13"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            timesheet = new Timesheet
            {
                Id = 4,
                EmployeeId = 2,
                Date = DateTime.Parse("2018-06-14"),
                HoursWorked = 12
            };
            timesheets.Add(timesheet);

            return timesheets;
        }
    }
}
