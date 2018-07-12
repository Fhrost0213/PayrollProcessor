using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public class EmployeeRepository : IEmployeeGetRepository
    {
        public Employee Get(int employeeId)
        {
            // Add implementation
            return new Employee
            {
                Id = 1,
                HourlyRate = 100,
                FirstName = "John",
                LastName = "Doe",
                State = State.TX
            };
        }

        public List<Employee> GetList(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
