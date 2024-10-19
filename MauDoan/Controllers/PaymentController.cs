using MauDoan.Context;
using MauDoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauDoan.Controllers
{
    public class PaymentController : Controller
    {
        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        // GET: Payment
        public ActionResult Index()
        {
            //if (Session["idUser"] == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            //else
            //{
            //    // lấy thông tin từ giỏ hàng từ biến sessin
            //    var lstCart = (List<CartModel>)Session["cart"];
            //    // gán dữ liệu cho order
            //    Ordertable objordertable = new Ordertable();
            //    objordertable.user_id = Session["idUser"].ToString();
            //    objordertable.order_date = DateTime.Now;
            //    objordertable.total_amount = 1;
            //    objAlistyleEntities1.Ordertable.Add(objordertable);

            //    objAlistyleEntities1.SaveChanges();

            //    Console.WriteLine("in ra" + objAlistyleEntities1.SaveChanges());
            //    string stringOrderid = objordertable.id.ToString();
            //    List<Order_detail> lstOrderDetails = new List<Order_detail>();

            //    foreach (var item in lstCart)
            //    {
            //        Order_detail obj = new Order_detail();
            //        obj.quantity = item.quantity;
            //        obj.order_id = stringOrderid;
            //        obj.product_id = item.Product.id;
            //        lstOrderDetails.Add(obj);
            //    }
            //    objAlistyleEntities1.Order_detail.AddRange(lstOrderDetails);
            //    objAlistyleEntities1.SaveChanges();
            //}

            return View();
        }
    }
}