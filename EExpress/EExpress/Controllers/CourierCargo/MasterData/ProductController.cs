using EExpress.Models;
using EExpress.Models.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Controllers.CourierCargo.MasterData
{
    public class ProductController : Controller
    {
        ProductDbHandler db = new ProductDbHandler();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            var listProduct = db.GetProducts();

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(Guid id)
        {
            var product = db.GetProductById(id);

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.AddEditProduct(product);
            }

            string status = product.id != Guid.Empty ? "updated" : "saved";
            string message = $"Product has been {status} successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}