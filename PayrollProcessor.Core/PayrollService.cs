using System;
using System.Collections.Generic;
using System.Linq;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.Repositories;

namespace PayrollProcessor.Core
{
    public class PayrollService
    {
        private readonly ITimesheetGetRepository _timesheetRepository;
        private readonly IEmployeeGetRepository _employeeRepository;

        public PayrollService(ITimesheetGetRepository timesheetRepository, IEmployeeGetRepository employeeRepository)
        {
            _timesheetRepository = timesheetRepository;
            _employeeRepository = employeeRepository;
        }

        public List<Paystub> GetPaystubs(DateTime date)
        {
            var paystubs = new List<Paystub>();
            var timesheets = _timesheetRepository.GetTimesheetsForLastTwoWeeks(date);

            var timesheetsByEmployee = timesheets.GroupBy(t => t.EmployeeId);

            foreach (var employeesTimesheets in timesheetsByEmployee)
            {
                var employee = _employeeRepository.Get(employeesTimesheets.First().EmployeeId);
                var employeeState = employee.State;
                var employeePayRate = employee.HourlyRate;

                var calculator = new OvertimeCalculatorFactory().GetCalculator(employeeState);

                // This was clean until I split these up into weeks. Clean this up?
                var firstWeekTimesheets = employeesTimesheets
                    .Select(t => t)
                    .Where(d => d.Date >= date.AddDays(-6) && d.Date <= date);

                var secondWeekTimesheets = employeesTimesheets
                    .Select(t => t)
                    .Where(d => d.Date >= date.AddDays(-13) && d.Date <= date.AddDays(-7));

                var firstDto = calculator.CalculatePay(firstWeekTimesheets.Select(t => t), employeePayRate);
                var secondDto = calculator.CalculatePay(secondWeekTimesheets.Select(t => t), employeePayRate);
                var dto = new PayDto(firstDto.RegularHoursWorked + secondDto.RegularHoursWorked, firstDto.OvertimeHoursWorked + secondDto.OvertimeHoursWorked, firstDto.RegularPay + secondDto.RegularPay, firstDto.OvertimePay + secondDto.OvertimePay);

                var paystub = new Paystub(employee, date.AddDays(-13), date, dto);
                paystubs.Add(paystub);
            }

            return paystubs;
        }
    }
}
