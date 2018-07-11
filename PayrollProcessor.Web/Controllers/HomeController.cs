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
            return View(new PaystubModel());
        }

        [HttpPost]
        public ActionResult GetPaystubs(PaystubModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["Paystubs"] = model.GetPaystubs(model.Date);

                //ViewData["EmployeeName"] = employee.FirstName + " " + employee.LastName;
                //ViewData["Date"] = date;
            }

            return View("Index", model);
        }
    }
}