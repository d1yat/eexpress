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

        public JsonResult GetCustomers()
        {
            var listCustomer = db.GetCustomers();

            return Json(listCustomer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerById(Guid id)
        {
            var customer = db.GetCustomerById(id);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.AddEditCustomer(customer);
            }

            string status = customer.id != Guid.Empty ? "updated" : "saved";
            string message = $"User has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTermInvoice(Guid id)
        {
            var termInvoice = db.GetTermInvoice(id);

            return Json(termInvoice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditTermInvoice(TermInvoice termInvoice)
        {
            if (ModelState.IsValid)
            {
                db.AddTermInvoice(termInvoice);
            }

            string status = termInvoice.cust_id != Guid.Empty ? "updated" : "saved";
            string message = $"Term Invoice has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}