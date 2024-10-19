using MauDoan.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MauDoan.Common;

namespace MauDoan.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        private object dtCategory;

        // GET: Admin/Product
        public ActionResult Index()
        {
            List<Product> lstProduct = new List<Product>();
            lstProduct = objAlistyleEntities1.Product.ToList();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Common objCommon = new Common();
            // lấy dữ liệu danh mục dưới DB
            var lstCat = objAlistyleEntities1.Category.ToList();
            // convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "id", "name");


            return View();
        }

        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        // ten hinh
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        // png
                        fileName = fileName + extension;
                        // tenhinh.png
                        objProduct.logo = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));

                    }

                    objProduct.CreatedOnUtc = DateTime.Now;
                    objAlistyleEntities1.Product.Add(objProduct);
                    objAlistyleEntities1.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);

        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var objProduct = objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var objProduct = objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();

            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objAlistyleEntities1.Product.Where(n => n.id == objPro.id).FirstOrDefault();
            objAlistyleEntities1.Product.Remove(objProduct);
            objAlistyleEntities1.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Common objCommon = new Common();
            // lấy dữ liệu danh mục dưới DB
            var lstCat = objAlistyleEntities1.Category.ToList();
            // convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "id", "name");

            var objProduct = objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();
            //return View();
            //var objProduct = objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();

            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit(string id, Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                // ten hinh
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                // png
                fileName = fileName + extension;
                // tenhinh.png
                objProduct.logo = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));

            }
            objAlistyleEntities1.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;

            objAlistyleEntities1.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}