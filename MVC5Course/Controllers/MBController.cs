using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [LocalDebugOnly]
    [HandleError(ExceptionType = typeof(DbEntityValidationException),View = "Error_DbEntityValidationException")]
    public class MBController : BaseController
    {
        [Share頁面上常用的ViewBag變數資料]
        // GET: MB
        public ActionResult Index()
        {
            ViewData["temp1"] = "暫存資料 Templ";
            var b = new ClientLoginViewModel()
            {
                FirstName = "Et",
                LastName = "KK",
                MiddleName = "DE",
                DateOfBirth = DateTime.Now
            };

            ViewData["ed"] = b;
            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = c;
                return RedirectToAction("MyFormResult");
            }
            return View();
        }

        public ActionResult MyFormResult()
        {
            
            return View();
        }

        public ActionResult ProductList()
        {
            var data = db.Product.OrderByDescending(x=>x.ProductId).Take(10);
            return View(data);
        }

        [HttpPost]
        public ActionResult BatchUpdate(ProductBatchUpdateViewModel[] items)
        {
           
            if (ModelState.IsValid)
            {
                foreach (var item in items )
                {
                    var product = db.Product.Find(item.ProductId);

                    product.ProductName = item.ProductName;
                    product.Active = item.Active;
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                }
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            
            return View();
        }

        public ActionResult MyError()
        {
            throw new InvalidOperationException("ERROR");
            return View();
        }

    }
}