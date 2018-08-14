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

        //public JsonResult GetCustomers()
        //{
        //    var listCustomer = db.GetCustomers();

        //    return Json(listCustomer, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        public JsonResult GetCustomers(int pageIndex, int pageSize)
        {
            var listCustomer = db.GetCustomers(pageIndex, pageSize);

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
                db.AddEditTermInvoice(termInvoice);
            }

            string status = termInvoice.cust_id != Guid.Empty ? "updated" : "saved";
            string message = $"Term Invoice has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDivisi(Guid customerId)
        {
            var listDivisi = db.GetDivisi(customerId);

            return Json(listDivisi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDivisiById(Guid id)
        {
            var divisi = db.GetDivisiById(id);

            return Json(divisi, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditDivisi(Divisi divisi)
        {
            if (ModelState.IsValid)
            {
                db.AddEditDivisi(divisi);
            }

            string status = divisi.id != Guid.Empty ? "updated" : "saved";
            string message = $"Term Invoice has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}