using System;

namespace PayrollProcessor.Core.Workweek
{
   public class StandardWorkweek : IWorkweek
    {
        public DayOfWeek StartOfWorkWeekDay
        {
            get { return DayOfWeek.Monday; }
        }

        public DayOfWeek EndOfWorkWeekDay
        {
            get { return DayOfWeek.Sunday; }
        }
    }
}
