using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class CityController : Controller
    {
        CityDbHandler db = new CityDbHandler();

        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCities()
        {
            var listCity= db.GetCities();

            return Json(listCity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityByCityCode(string cityCode)
        {
            var city = db.GetCityByCityCode(cityCode);

            return Json(city, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditCity(City city)
        {
            if (ModelState.IsValid)
            {
                db.AddEditCity(city);
            }

            string status = !string.IsNullOrEmpty(city.kdkota) ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}