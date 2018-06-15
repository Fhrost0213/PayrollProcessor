using System;

namespace PayrollProcessor.Core.Entities
{
    public class Paystub
    {
        public Paystub(Employee employee, DateTime startDate, DateTime endDate, PayDto dto)
        {
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            TotalRegularHoursWorked = dto.RegularHoursWorked;
            TotalOvertimeHoursWorked = dto.OvertimeHoursWorked;
            TotalRegularPay = dto.RegularPay;
            TotalOvertimePay = dto.OvertimePay;
        }
        
        public Employee Employee { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public decimal TotalRegularHoursWorked { get; }
        public decimal TotalOvertimeHoursWorked { get; }
        public decimal TotalRegularPay { get; }
        public decimal TotalOvertimePay { get; }
    }
}
