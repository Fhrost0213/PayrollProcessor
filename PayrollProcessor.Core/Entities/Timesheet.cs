using System;

namespace PayrollProcessor.Core.Entities
{
    public class Timesheet : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal HoursWorked { get; set; }

        public int EmployeeId { get; set; }

    }
}
