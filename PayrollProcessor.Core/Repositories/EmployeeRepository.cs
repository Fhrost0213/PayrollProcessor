using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public Employee Get(int employeeId)
        {
            // Add implementation
            return new Employee
            {
                Id = 1,
                PayRate = 100
            };
        }

        public List<Employee> GetList(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
