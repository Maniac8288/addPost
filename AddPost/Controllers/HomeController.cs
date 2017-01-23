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
         
            return View();
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
        /// <summary>
        /// Страница с определенным постом
        /// </summary>
        /// <param name="id">ид определенного поста</param>
        /// <returns>Вызывает метод определяющий ИД</returns>
        public ActionResult Post(int id)
        {
            return View(PostDataStorage.Storage.GetPostById(id));
        }
        /// <summary>
        /// Страница с выбором постов, которые нужно изменить
        /// </summary>
        /// <returns>Вывод всех постов</returns>
        public ActionResult ChooseEditPost()
        {
            return View(PostDataStorage.Storage.GetAllPost());
        }
        public ActionResult EditPost()
        {
            return View();
        }
    }
}