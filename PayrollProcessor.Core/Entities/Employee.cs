namespace PayrollProcessor.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        // Should pay rate be here? Think about UI once we add that
        public decimal HourlyRate { get; set; }
    }
}
