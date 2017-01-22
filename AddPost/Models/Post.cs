using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddPost.Models
{
    public class Post
    {/// <summary>
    /// Название поста
    /// </summary>
         public string NamePost { get; set; }
        /// <summary>
        /// Коллекция постов
        /// </summary>
        public static List<string> Category = new List<string>()
        {
            "Медицина",
            "Спорт",
            "Новости",
            "Истории",
            "Политика",
             "Кино"
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
        /// <summary>
        /// Дата создания
        /// </summary>
        public string dateAddPost { get; set; }
        public string upload { get; set; }
        
    }
   
}