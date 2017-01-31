using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddPost.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Post
    {/// <summary>
    /// Название поста
    /// </summary>
         public string NamePost { get; set; }
        /// <summary>
        /// Коллекция постов
        /// </summary>
        public static List<Category> Category = new List<Category>()
        {
            new Category()
            {
                Name="Новости",
                Childrens= new List<Category> {new Category() {Name="Спорт" },new Category() {Name="Политика" } }
            },
            new Category()
            {
                Name="Кино",
                Childrens=new List<Models.Category> {new Category() {Name="Драма" },new Category() {Name="Фантастика"}, new Category() { Name = "Ужасы" }, new Category() { Name = "Триллер" } }
            },
            new Category()
            {
                Name="Медицниа",
                Childrens = new List<Models.Category> {new Category() { Name="Народная медицина"}, new Category() { Name = "Советы от врачей" } }
            }
            

        };
  
        public string selectedCategory { get; set; }
        /// <summary>
        /// Содержимое поста
        /// </summary>
        public string contentPost { get; set; }
        /// <summary>
        /// Тэги
        /// </summary>
        public string Tags { get; set; }
 
        public List<string> CollectionTags = new List<string>();
        /// <summary>
        /// Дата создания
        /// </summary>
        public string dateAddPost { get; set; }
        /// <summary>
        /// Название картинки
        /// </summary>
        public List<string> upload = new List <string>();
        public int PostID { get; set; }
    }
   
}