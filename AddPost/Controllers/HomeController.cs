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
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод всех постов</returns>
        public ActionResult Index()
        {
            return View( PostDataStorage.Storage.GetAllPost());
        }
        /// <summary>
        /// Страница добовления поста на сайт
        /// </summary>
        /// <returns>Новый объект модели</returns>
        [HttpGet]
        public ActionResult AddPost()
        {
         
            return View(new Post());
        }
        /// <summary>
        /// Добовление поста в коллекцию
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="upload">Добавление картинки</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                model.upload=fileName;
                // сохраняем файл в папку img в проекте
                upload.SaveAs(Server.MapPath("~/img/" + fileName));
            }
            PostDataStorage.Storage.AddPost(model);
                return View();
        }
        public ActionResult Post(int id)
        {
            return View(PostDataStorage.Storage.GetPostById(id));
        }
    }
}