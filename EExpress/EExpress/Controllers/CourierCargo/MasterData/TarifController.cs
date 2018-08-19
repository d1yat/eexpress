using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class TarifController : Controller
    {
        TarifDbHandler db = new TarifDbHandler();

        // GET: Tarif
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTarif()
        {
            var listTarif = db.GetTarif();

            return Json(listTarif, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCities()
        {
            var listCity = db.GetCities();

            return Json(listCity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityById(string kdkota)
        {
            var city = db.GetCityByCityCode(kdkota);

            return Json(city, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetShipmentType()
        {
            var listShipmentType = db.GetShipmentType();

            return Json(listShipmentType, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduct()
        {
            var listProduct = db.GetProduct();

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditTarif(Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                db.AddEditTarif(tarif);
            }

            string status = tarif.id != Guid.Empty ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}