using System;
using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public interface ITimesheetGetRepository
    {
        List<Timesheet> GetTimesheetsForLastTwoWeeks(DateTime date);
    }
}