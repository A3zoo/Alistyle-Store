using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MauDoan.Context;
using MauDoan.Models;

namespace MauDoan.Controllers
{
    public class HomeController : Controller
    {
        AlistyleEntities1 objAlistyleEntities1 = new AlistyleEntities1();
        public ActionResult Index()
        {
            //var homeModel = new HomeModel 
            //{ ListCategory = objAlistyleEntities1.Category.OrderByDescending(n => n.id).ToList(), 
            //  ListProduct = objAlistyleEntities1.Product.ToList() };

            //return View(homeModel);

            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = objAlistyleEntities1.Product.ToList();
            objHomeModel.ListCategory = objAlistyleEntities1.Category.ToList();
            return View(objHomeModel);


        }
        [HttpGet]
        public ActionResult Registers()
        {
            return View();
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registers(Users _user)
        {
            if (ModelState.IsValid)
            {
                var check = objAlistyleEntities1.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    objAlistyleEntities1.Configuration.ValidateOnSaveEnabled = false;
                    objAlistyleEntities1.Users.Add(_user);
                    objAlistyleEntities1.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View("Index");
        }

  


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = objAlistyleEntities1.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                Console.WriteLine("Code chạy đến đây");

                if (data.Count() > 0)
                {
                    Console.WriteLine("Bắt đầu chương trình...");
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Password"] = data.FirstOrDefault().Password;
                    Session["idUser"] = data.FirstOrDefault().user_id;
                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine("Codeelse");
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Registers");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}