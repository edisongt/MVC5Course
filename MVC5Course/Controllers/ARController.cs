using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return View();
        }

        public ActionResult FileTest()
        {
            var filepath = Server.MapPath("~/Content/happy-jumping-sheep.jpg");
            return File(filepath, "image/jpeg");
        }
        public ActionResult FileTest2()
        {
            var filepath = Server.MapPath("~/Content/happy-jumping-sheep.jpg");
            return File(filepath, "image/jpeg", "takeSheep.jpg");
        }

        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.OrderByDescending(x => x.ProductId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}