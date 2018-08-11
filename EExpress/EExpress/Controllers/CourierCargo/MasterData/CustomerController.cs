using EExpress.Models;
using EExpress.Models.DbHandlers;
using EExpress.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class CustomerController : Controller
    {
        CustomerDbHandler db = new CustomerDbHandler();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if(customer.custno != Guid.Empty)
                {
                    // Edit Mode
                    db.Edit(customer);
                }
                else
                {
                    // Add Mode
                    db.Add(customer);
                }

            }

            string status = customer.custno != null ? "updated" : "saved";
            string message = $"User has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomers()
        {
            var listCustomer = db.GetCustomers();

            return Json(listCustomer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerById(string id)
        {
            var customer = db.GetCustomerById(id);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
    }
}