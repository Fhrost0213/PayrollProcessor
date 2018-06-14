using System;
using PayrollProcessor.Core.Workweek;

namespace PayrollProcessor.Core.Paystub
{
    public class PaystubDateGetter
    {
        private readonly IWorkweek _workweek;

        public PaystubDateGetter(IWorkweek workweek)
        {
            _workweek = workweek;
        }

        public PaystubDateHelperDto GetPaystubDates(DateTime date)
        {
            DateTime startDate;
            DateTime endDate = date;

            // Walk back last 7 days to find end of pay period
            for (var d = date; d >= date.AddDays(-7); d = d.AddDays(-1))
            {
                // Find closest end of period
                if (d.DayOfWeek == _workweek.EndOfWorkWeekDay)
                {
                    endDate = d;
                }
            }

            startDate = endDate.AddDays(-13);

            return new PaystubDateHelperDto {StartDate = startDate, EndDate = endDate};
        }
    }
}
