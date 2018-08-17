using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class ValutaController : Controller
    {
        ValutaDbHandler db = new ValutaDbHandler();

        // GET: Valuta
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetValuta()
        {
            var listValuta = db.GetValuta();

            return Json(listValuta, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetValutaById(string kode)
        {
            var valuta = db.GetValutaById(kode);

            return Json(valuta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditValuta(Valuta valuta)
        {
            if (ModelState.IsValid)
            {
                db.AddEditValuta(valuta);
            }

            string status = !string.IsNullOrEmpty(valuta.kode) ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}