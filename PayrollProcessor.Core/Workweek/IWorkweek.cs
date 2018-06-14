using System;

namespace PayrollProcessor.Core.Workweek
{
    public interface IWorkweek
    {
        DayOfWeek StartOfWorkWeekDay { get; }

        DayOfWeek EndOfWorkWeekDay { get; }
    }
}
