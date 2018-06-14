using System;

namespace PayrollProcessor.Core.Entities
{
    public class Paystub
    {
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRegularHoursWorked { get; set; }
        public decimal TotalOvertimeHoursWorked { get; set; }
        public decimal TotalRegularPay { get; set; }
        public decimal TotalOvertimePay { get; set; }
    }
}
