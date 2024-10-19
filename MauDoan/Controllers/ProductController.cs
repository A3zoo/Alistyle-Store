using MauDoan.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MauDoan.Controllers
{
    public class ProductController : Controller
    {

        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        // GET: Product
        public Product GetObjProduct(string id)
        {
            return objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();
        }

        public ActionResult Detail(string id, Product objProduct)
        {
            var product = objAlistyleEntities1.Product.Where(n => n.id == id).FirstOrDefault();
            return View(product);
        }


        

        
        
    }
}