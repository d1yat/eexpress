using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class SignatureController : Controller
    {
        SignatureDbHandler db = new SignatureDbHandler();

        // GET: Signature
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSignature()
        {
            var listSignature = db.GetSignature();

            return Json(listSignature, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSignatureDetails()
        {
            var origin = db.GetSignatureDetails();

            return Json(origin, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditSignature(Signature signature)
        {
            if (ModelState.IsValid)
            {
                db.AddEditSignature(signature);
            }

            string status = !string.IsNullOrEmpty(signature.DomainCode) ? "updated" : "saved";
            string message = $"Signature has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}