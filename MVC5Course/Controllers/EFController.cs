﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {


            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }

        public ActionResult Create()
        {
            var product = new Product()
            {
                ProductName = "White Cat",
                Price = 10,
                Active = true,
                Stock = 9,

            };

            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var product = db.Product.Find(Id);
            return View(product);
        }


        public ActionResult Delete(int Id)
        {

            var product = db.Product.Find(Id);
            // 錯誤示範 (以下範例不要抄)
            /*
            foreach (var item in product.OrderLine.ToList())
            {
                db.OrderLine.Remove(item);
                db.SaveChanges();
            }
            */
            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName = product.ProductName + "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName+"發生錯誤"+vErrors.ErrorMessage);
                    }
                }                
            }
            return RedirectToAction("Index");
        }


        public ActionResult Add20Percent()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            foreach (var item in data)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price * 1.2m;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClientContribution()
        {
            var data = db.vw_ClientContribution.Take(10);
            return View(data);
        }
    }
}