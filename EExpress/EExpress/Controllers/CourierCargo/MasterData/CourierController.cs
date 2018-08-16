using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class CourierController : Controller
    {
        CourierDbHandler db = new CourierDbHandler();

        // GET: Courier
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCourier()
        {
            var listCourier = db.GetCourier();

            return Json(listCourier, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourierById(string id)
        {
            var courier = db.GetCourierById(id);

            return Json(courier, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditCourier(Courier courier)
        {
            if (ModelState.IsValid)
            {
                db.AddEditCourier(courier);
            }

            string status = !string.IsNullOrEmpty(courier.kode) ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}