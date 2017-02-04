﻿using PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AddPost.Models
{
    public class PostDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static PostDataStorage Storage = new PostDataStorage();
        /// <summary>
        /// Коллекция постов
        /// </summary>
        public List<Post> postList = new List<Post>();
        /// <summary>
        /// Инициализация коллекции
        /// </summary>
        public PostDataStorage()
        {
            postList.Add( new Post {
                    NamePost = "Шерлок",
                    PostID = 1,
                    selectedCategory = "Триллер",
                    contentPost = "Можно было ожидать, что 3 серия начнется с того, чем закончилась предыдущая — с того, что Эвр Холмс стреляет в Ватсона.  Однако вместо Эвр мы видим девочку, которая одна проснулась в летящем самолете, полном спящих пассажиров и членов экипажа.  Девочка пытается найти хоть кого-то, кто не спит, но все безрезультатно. Когда она берет трубку звонящего мобильного телефона, из динамика слышен голос Мориарти, который сообщает девочке, что это «ее последняя проблема.Мйакрофт смотрит старый фильм в личном кинотеатре,расположенном в подвале его дома.Леди Смоллвуд нигде не видно, а посему не вполне понятно, зачем на вероятных отношениях межу этой женщиной и Майкрофтом в прошлой серии был сделан такой акцент.В середине просмотра фильм прерывается сообщением «Я вернулась».  Кто - то произносит имя Майкрофта,фильм превращается в мелькающий хаос.Майкрофт чует неладное.Он  вооружается мечом,замаскированным под зонтик.Возможность возвращения Эвр ужасает Майкрофта. «Ты же не могла сбежать из…», — бормочет брат Шерлока.Оказывается,никакого возвращения Эвр не произошло — все странности в доме Майкрофта были уловкой Шерлока,которая должна была заставить брата признать, что он скрывает существование Эвр.Оказывается,Эвр во 2 серии 4 сезона стреляла в Ватсона всего - лишь из усыпляющего пистолета.Шерлок приглашает Майкрофта на Бейкер стрит для серьезного разговора.На следующее утро Майкрофт,Шерлок и Ватсон собираются в квартире на Бейкер стрит.Майкрофт требует,чтобы Ватсон ушел,поскольку будут обсуждаться семейные дела,однако Шерлок отклоняет это требование.Майкрофт рассказывает,что Эвр с самых ранних лет была гением,превосходящим Исаака Ньютона.Однако у личности Эвр была темная сторона.Она украла любимую собаку Шерлока и не говорила никому,где ее прячет.Собаку так и не нашли.Когда она вознамерилась убить самого Шерлока,Эвр изолировали в Шерринфорде — специальной тюрьме,расположенной на острове.Майкрофт сравнил это место с адом.",
                   CollectionTags = {"Шерлок", "Сериал" },
                    dateAddPost = "2017-01-14",
                    upload = { "sherlok.jpg", "2sherlok.png" }
         
                });
            postList.Add(new Post
            {
                NamePost = "Патронус - Гарри Поттер",
                PostID = 2,
                selectedCategory = "Фантастика",
                contentPost = "Патронус (от patronus — покровитель) — магическая сущность, вызываемая заклинанием «Экспекто патронум». Служит как защита от дементоров. Может быть выражена как просто облако серебристого пара, так и обретать различные формы (так называемый «телесный патронус»). «Телесные патронусы» принимают обычно вид какого-либо животного, соответствующего характеру вызвавшего его волшебника. В «боевых условиях» Патронуса под силу вызвать только сильному, опытному волшебнику, так как это очень сложная магия. Для вызова Патронуса нужно вспомнить самые счастливые воспоминания, иначе кроме вспышки света ничего не получится.Чары вызова Патронуса очень древние,подлинно неизвестно,  когда они были изобретены.Форма и размер Патронуса ни в коей мере не влияют на его силу.Известен случай, когда Патронус в виде крошечной мыши прогнал целую стаю дементоров.Также форма Патронуса может изменяться на протяжении жизни волшебницы или волшебника.Известны примеры,когда форма Патронуса изменяется в результате тяжелой утраты,когда человек влюбляется или если произошли глубокие изменения в характере личности.Некоторые волшебницы и волшебники вообще не могут произвести Патронус до тех пор,пока они не переживут какой - нибудь психологический шок.",
                CollectionTags = { "Гарри Поттер", "Патронус", "Магия" },
                dateAddPost = "2017-01-23",
                upload = { "Garry.jpg", "2garry.jpg" }
            });
         

        }
        /// <summary>
        /// Вывод коллекции
        /// </summary>
        /// <returns>Список постов</returns>
        public List<Post> GetAllPost()
        {
      
            return postList;
        }
        /// <summary>
        /// Добавление нового поста в колекцию
        /// </summary>
        /// <param name="model">Объект ProductModel</param>
        public void AddPost(Post model)
        {
            if (postList.Count < 1)
            {
                model.PostID = 1;
            }
            else {
            model.PostID = postList.Count + 1;
            }
            model.CollectionTags = model.Tags.Split(new char[] { ',' }).ToList();
            postList.Add(model);
           
        }
        /// <summary>
        /// Определяет ИД и возвращает значение 
        /// </summary>
        /// <param name="PostID">Ид поста</param>
        /// <returns>возвращает int переменную равную ID поста</returns>
        public Post GetPostById(int? PostID)
        {
            return postList.Find(x => x.PostID == PostID);
        }
        /// <summary>
        /// Обновление информации о посте
        /// </summary>
        /// <param name="model"></param>
        public void EditPost(Post model)
        {  ///Замена старой модели на новую
            var oldModel = postList.Find(x => x.PostID == model.PostID);
            if (oldModel == null)
            {
                return;
            }
            if (model.upload.Count == 0) { model.upload = oldModel.upload; }
            postList.Remove(oldModel);
            model.CollectionTags = model.Tags.Split(new char[] { ',' }).ToList();
            postList.Add(model);

        }
        /// <summary>
        /// Удаляет пост
        /// </summary>
        /// <param name="PostID"></param>
        public void DeletePost(int PostID)
        {
            
            var model = postList.Find(x => x.PostID == PostID);
            if (model == null)
            {
                return;
            }
            
            
          
            postList.Remove(model);
        }
        /// <summary>
        /// Метод поиска постов по заданному тегу
        /// </summary>
        /// <param name="Tag">Имя тега</param>
        /// <returns>Список постов</returns>
        public List<Post> GetPostByTag(string Tag)
        {
            return postList.FindAll(x => x.CollectionTags.Contains(Tag));
        }
       public List<Post> GetPostByCategory (string category)
        {
            return postList.FindAll(x => x.selectedCategory.Contains(category));
        }
     public   string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
        public  string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }

    }

}