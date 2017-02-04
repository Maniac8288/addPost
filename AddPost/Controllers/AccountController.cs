using AddPost.Infrastructura;
using DataModel;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddPost.Models;

namespace AddPost.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            string pw3 = PostDataStorage.Storage.GetHashString(password);
            WebUser.Login(userName, pw3);
            ModelUser user = WebUser.CurrentUser;
            if (user.IsAuth == true)
            {
                Session["user"] = user;

                if (Request.Cookies["User"] == null)
                {
                    HttpCookie cookie = new HttpCookie("User");
                    cookie["UserName"] = user.UserName;
                    cookie["Password"] = pw3;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
            }
        

            return RedirectToAction("index", "home");
        }
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            if (Request.Cookies["User"] != null)
            {
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index", "home");

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string pw1,string pw2) {

           string pw3=  PostDataStorage.Storage.GetHashString(pw1);
            string salt = PostDataStorage.Storage.getSalt();
            using (var db = new DataContext())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = salt + pw3,
                    Salt = salt
                    
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("index", "home");
        }
    }
}