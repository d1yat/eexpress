using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class PODStatusController : Controller
    {
        PODStatusDbHandler db = new PODStatusDbHandler();

        // GET: PODStatus
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPODStatus()
        {
            var listPODStatus = db.GetPODStatus();

            return Json(listPODStatus, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPODStatusById(Guid id)
        {
            var podStatus = db.GetPODStatusById(id);

            return Json(podStatus, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditPODStatus(PODStatus podStatus)
        {
            if (ModelState.IsValid)
            {
                db.AddEditPODStatus(podStatus);
            }

            string status = podStatus.id != Guid.Empty ? "updated" : "saved";
            string message = $"POD Status has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}