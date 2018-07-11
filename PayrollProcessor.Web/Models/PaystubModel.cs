using System;
using System.Collections.Generic;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.Repositories;

namespace PayrollProcessor.Web.Models
{
    public class PaystubModel
    {
        private readonly ITimesheetGetRepository _timesheetRepo;
        private readonly IEmployeeGetRepository _employeeRepo;

        public PaystubModel()
        {
            _timesheetRepo = new TimesheetRepository();
            _employeeRepo = new EmployeeRepository();
        }

        public DateTime Date { get; set; }

        public List<Paystub> GetPaystubs(DateTime date)
        {
            var service = new Core.PayrollService(_timesheetRepo, _employeeRepo);
            return service.GetPaystubs(date);
        }
    }
}