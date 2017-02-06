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
using IServices.SubIntefac;

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
        public ActionResult Login(string userName, string password, string RememberMe)
        {
            WebUser.Login(userName, password, RememberMe);
            return RedirectToAction("index", "home");
        }
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            return RedirectToAction("index", "home");

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string pw1) {

            WebUser.Register(userName, pw1);
            return RedirectToAction("index", "home");
        }
    }
}