using System;

namespace PayrollProcessor.Core.Entities
{
    public class Paystub
    {
        public Paystub(Employee employee, DateTime startDate, DateTime endDate, decimal totalRegularHoursWorked, decimal totalOvertimeHoursWorked, decimal totalRegularPay, decimal totalOvertimePay)
        {
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            TotalRegularHoursWorked = totalRegularHoursWorked;
            TotalOvertimeHoursWorked = totalOvertimeHoursWorked;
            TotalRegularPay = totalRegularPay;
            TotalOvertimePay = totalOvertimePay;
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
