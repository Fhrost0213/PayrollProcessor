using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public interface IEmployeeGetRepository : IGetRepository
    {
        Employee Get(int employeeId);
        List<Employee> GetList(int id);
    }
}