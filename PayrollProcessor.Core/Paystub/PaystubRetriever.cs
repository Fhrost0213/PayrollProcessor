using System;
using System.Linq;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.OvertimeCalculators;
using PayrollProcessor.Core.Repositories;
using PayrollProcessor.Core.Workweek;

namespace PayrollProcessor.Core.Paystub
{
    public class PaystubRetriever
    {
        private readonly IRepository<Timesheet> _timesheetRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public PaystubRetriever(IRepository<Timesheet> timesheetRepository, IRepository<Employee> employeeRepository)
        {
            _timesheetRepository = timesheetRepository;
            _employeeRepository = employeeRepository;
        }

        public Entities.Paystub RetrievePaystub(DateTime date, int employeeId)
        {
            var paystub = new Entities.Paystub();

            var timesheets = _timesheetRepository.GetList(employeeId);

            // Gets paystub for last 2 weeks of work
            var paystubDates = new PaystubDateGetter(new StandardWorkweek()).GetPaystubDates(date);
            paystub.StartDate = paystubDates.StartDate;
            paystub.EndDate = paystubDates.EndDate;

            var validTimesheets =
                timesheets.Where(t => t.Date >= paystubDates.StartDate && t.Date <= paystubDates.EndDate);

            var employee = _employeeRepository
                .Get(employeeId);
            paystub.Employee = employee;

            var payRate = employee.PayRate;

            return new PaystubCalculator(new TexasOvertimeCalculator(), payRate).CalculatePaystub(paystub, validTimesheets);
        }
    }
}
