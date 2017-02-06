using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddPost.Models;
using PagedList.Mvc;
using PagedList;
using AddPost.Infrastructura;

namespace AddPost.Controllers
{
    public class HomeController : BaseController
    {
        Post db = new Models.Post();


        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод всех постов отсортированне по дате </returns>
        public ActionResult Index()
        {
            return View(PostDataStorage.Storage.GetAllPost().OrderByDescending(x => x.dateAddPost));
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
        public ActionResult AddPost(Post model, IEnumerable<HttpPostedFileBase> upload)
        {
            PostDataStorage.Storage.AddPost(model);

            foreach (var file in upload)
            {

                if (file != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    model.upload.Add(fileName);
                    // сохраняем файл в папку img в проекте
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
                    file.SaveAs(Server.MapPath("~/img/" + model.PostID + "/" + fileName));
                }
            }
            return RedirectToAction("Index");
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
        [FilterUser(Roles ="Admin")]
        public ActionResult ChooseEditPost()
        {
            return View(PostDataStorage.Storage.GetAllPost().OrderByDescending(x => x.dateAddPost));
        }
        /// <summary>
        /// Метод удаление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Возвращает на главную страницу</returns>
        public ActionResult deletePost(int id, Post model)
        {
            string fullPath = Request.MapPath("~/img/" + id);
            if (System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.Delete(fullPath, true);
            }
            PostDataStorage.Storage.DeletePost(id);
            return RedirectToAction("ChooseEditPost");
        }
        /// <summary>
        /// вызывает страницу с редактирование поста по определенному ид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditPost(int id)
        {

            return View(PostDataStorage.Storage.GetPostById(id));
        }
        /// <summary>
        /// Метод редактирование поста
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="upload"></param>
        /// <returns>Возвращает на страницу пост</returns>
        [FilterUser(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPost(int id, Post model, IEnumerable<HttpPostedFileBase> upload)
        {
            foreach (var file in upload)
            {

                if (file != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    model.upload.Add(fileName);
                    // сохраняем файл в папку img в проекте
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
                    file.SaveAs(Server.MapPath("~/img/" + model.PostID + "/" + fileName));
                }

            }
            PostDataStorage.Storage.EditPost(model);
            return View("Post", model);
        }
        [HttpGet]
        public ActionResult Tag(string tags)
        {

            return View(PostDataStorage.Storage.GetPostByTag(tags));
        }
        public ActionResult Category(string category)
        {
            return View(PostDataStorage.Storage.GetPostByCategory(category));
        }
    }
}