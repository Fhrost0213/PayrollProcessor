using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.OvertimeCalculators
{
    public interface IOvertimeCalculator
    {
        PayDto CalculatePay(IEnumerable<Timesheet> timesheets, decimal payRate);
    }
}
