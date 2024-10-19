using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MauDoan.Context;
using MauDoan.Controllers;
using MauDoan.Models;

namespace MauDoan.Controllers
{
    
    public class CartController : Controller
    {
        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        // GET: Cart
        public ActionResult Cart()
        {
            return View((List<CartModel>)Session["cart"]);
        }
        private int IsExist(string id)
        {
            throw new NotImplementedException();
        }
        private int isExist(string id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.id.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult AddToCart(string id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objAlistyleEntities1.Product.Find(id), quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].quantity += quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { Product = objAlistyleEntities1.Product.Find(id), quantity = quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }





        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(string id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            int v = li.RemoveAll(x => x.Product.id == id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
    }
}
    
