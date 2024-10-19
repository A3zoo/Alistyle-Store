using MauDoan.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauDoan.Controllers
{
    public class CategoryController : Controller
    {
        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        // GET: Category
        public ActionResult Category()
        {
            var lstCategory = objAlistyleEntities1.Category.ToList();
            return View(lstCategory);
        }

        public ActionResult ProductCategory(string id)
        {
            var listProduct = objAlistyleEntities1.Product.Where(n => n.category_id == id).ToList();
            return View(listProduct);
        }
    }
}