using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddPost.Models;

namespace AddPost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View( PostDataStorage.Instance.GetAllPost());
        }
        [HttpGet]
        public ActionResult AddPost()
        {
         
            return View(new Post());
        }
        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                model.upload = fileName;
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/img/" + fileName));
            }
            PostDataStorage.Instance.AddPost(model);
                return View();
        }
    }
}