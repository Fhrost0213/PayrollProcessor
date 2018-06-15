using System.Data;

namespace PayrollProcessor.Core.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public State State { get; set; }

        // Should pay rate be here? Think about UI once we add that
        public decimal HourlyRate { get; set; }
    }
}
