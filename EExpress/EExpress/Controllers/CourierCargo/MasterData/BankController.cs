using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class BankController : Controller
    {
        BankDbHandler db = new BankDbHandler();

        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBank()
        {
            var listBank = db.GetBank();

            return Json(listBank, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBankById(string kdbank)
        {
            var valuta = db.GetBankById(kdbank);

            return Json(valuta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditBank(Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.AddEditBank(bank);
            }

            string status = !string.IsNullOrEmpty(bank.kdbank) ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}