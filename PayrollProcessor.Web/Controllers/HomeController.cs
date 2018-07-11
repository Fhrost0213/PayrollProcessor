using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.Repositories;
using PayrollProcessor.Web.Models;

namespace PayrollProcessor.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexModel());
        }

        [HttpPost]
        public ActionResult GetPaystubs(IndexModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["Paystubs"] = GetPaystubs(model.Date);

                //ViewData["EmployeeName"] = employee.FirstName + " " + employee.LastName;
                //ViewData["Date"] = date;
            }

            return View("Index", model);
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<Paystub> GetPaystubs(DateTime date)
        {
            var timesheetRepo = new TimesheetRepository();
            var employeeRepo = new EmployeeRepository();

            var service = new Core.PayrollService(timesheetRepo, employeeRepo);
            return service.GetPaystubs(date); 
        }
    }
}