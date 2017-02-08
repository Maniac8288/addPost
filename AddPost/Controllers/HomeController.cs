using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using AddPost.Infrastructura;
using PostModel;
using System.Data.Entity;
using PostModel.Models;
using System.IO;

namespace AddPost.Controllers
{
    public class HomeController : BaseController
    {
       


        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод всех постов отсортированне по дате </returns>
        public ActionResult Index(Post model)
        {
       
            return View(db.Posts.OrderByDescending(x => x.dateAddPost));
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
                    model.upload = fileName;
                    // сохраняем файл в папку img в проекте
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
                upload.SaveAs(Server.MapPath("~/img/" + model.PostID + "/" + fileName));
               
           
             
            }
            db.Posts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Страница с определенным постом
        /// </summary>
        /// <param name="id">ид определенного поста</param>
        /// <returns>Вызывает метод определяющий ИД</returns>
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            PostDataStorage.collectionsTags = PostDataStorage.Storage.TagsSplit(db.Posts.Find(id));
            return View(db.Posts.Find(id));
        }
        /// <summary>
        /// Страница с выбором постов, которые нужно изменить
        /// </summary>
        /// <returns>Вывод всех постов</returns>
      //  [FilterUser(Roles ="Admin")]
        public ActionResult ChooseEditPost()
        {
            return View(db.Posts.OrderByDescending(x => x.dateAddPost));
        }
        /// <summary>
        /// Метод удаление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Возвращает на главную страницу</returns>
        public ActionResult deletePost(int? id)
        {
            if(db.Posts.Find(id) == null)
            {
                return HttpNotFound();
            }
            string fullPath = Request.MapPath("~/img/" + id);
            if (System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.Delete(fullPath, true);
            }
            db.Posts.Remove(db.Posts.Find(id));
            db.SaveChanges();
            return RedirectToAction("ChooseEditPost");
        }
        /// <summary>
        /// вызывает страницу с редактирование поста по определенному ид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[FilterUser(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPost(int? id)
        {
            if( id == null)
            {
                return HttpNotFound();
            }
            if (db.Posts.Find(id) != null)
            {
                return View(db.Posts.Find(id));
            }
             return HttpNotFound();
        }
        /// <summary>
        /// Метод редактирование поста
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="upload"></param>
        /// <returns>Возвращает на страницу пост</returns>
    
        [HttpPost]
        public ActionResult EditPost(Post model, HttpPostedFileBase upload)
        {
            

                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    model.upload = fileName;
                    // сохраняем файл в папку img в проекте
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
                upload.SaveAs(Server.MapPath("~/img/" + model.PostID + "/" + fileName));
             


            }
            db.Entry(model).State = EntityState.Modified;
            if (upload == null)
            {
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath(("~/img/" + model.PostID + "/")));

                foreach (var item in dir.GetFiles())
                {
                    model.upload = item.ToString();
                }
             
            }
            db.SaveChanges();
            PostDataStorage.collectionsTags = PostDataStorage.Storage.TagsSplit(model);

            return View("Post", model);
        }
        [HttpGet]
        public ActionResult Tag(string tags)
        {

            return View(db.Posts.Where(x => x.Tags.Contains(tags)));
        }
        public ActionResult Category(string category)
        {
            return View(db.Posts.Where(x => x.selectedCategory == category));
        }
    }
}