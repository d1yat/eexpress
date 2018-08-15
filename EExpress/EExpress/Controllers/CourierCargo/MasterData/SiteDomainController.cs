using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class SiteDomainController : Controller
    {
        SiteDomainDbHandler db = new SiteDomainDbHandler();

        // GET: SiteDomain
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSiteDomain()
        {
            var listSiteDomain = db.GetSiteDomain();

            return Json(listSiteDomain, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrigin()
        {
            var listOrigin = db.GetOrigin();

            return Json(listOrigin, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOriginBySiteName(string siteName)
        {
            var origin = db.GetOriginBySiteName(siteName);

            return Json(origin, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditSiteDomain(SiteDomain siteDomain)
        {
            if (ModelState.IsValid)
            {
                db.AddEditSiteDomain(siteDomain);
            }

            string status = !string.IsNullOrEmpty(siteDomain.my_domain)  ? "updated" : "saved";
            string message = $"Site / Domain has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}