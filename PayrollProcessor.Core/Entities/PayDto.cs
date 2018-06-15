namespace PayrollProcessor.Core.Entities
{
    public class PayDto
    {
        public PayDto(decimal regularHoursWorked, decimal overtimeHoursWorked, decimal regularPay, decimal overtimePay)
        {
            RegularHoursWorked = regularHoursWorked;
            OvertimeHoursWorked = overtimeHoursWorked;
            RegularPay = regularPay;
            OvertimePay = overtimePay;
        }

        public decimal RegularHoursWorked { get; }
        public decimal OvertimeHoursWorked { get; }
        public decimal RegularPay { get; }
        public decimal OvertimePay { get; }
    }
}
