using System;

namespace PayrollProcessor.Core.Entities
{
    public class Timesheet
    {
        public DayOfWeek Day
        {
            get
            {
                return _date.DayOfWeek;
            }

        }
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public decimal HoursWorked { get; set; }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

    }
}
