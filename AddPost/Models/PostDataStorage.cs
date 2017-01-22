﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddPost.Models
{
    public class PostDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static PostDataStorage Instance = new PostDataStorage();
        /// <summary>
        /// Список имеющихся товаров
        /// </summary>
        public List<Post> postList = new List<Post>();
        /// <summary>
        /// Инициализация списка товаров
        /// </summary>
        public PostDataStorage()
        {
            postList.Add(
                new Post
                {        
                    NamePost = "Шерлок",
                    selectedCategory = "Другое",
                    contentPost = "Можно было ожидать, что 3 серия начнется с того, чем закончилась предыдущая — с того, что Эвр Холмс стреляет в Ватсона.  Однако вместо Эвр мы видим девочку, которая одна проснулась в летящем самолете, полном спящих пассажиров и членов экипажа.  Девочка пытается найти хоть кого-то, кто не спит, но все безрезультатно. Когда она берет трубку звонящего мобильного телефона, из динамика слышен голос Мориарти, который сообщает девочке, что это «ее последняя проблема.Мйакрофт смотрит старый фильм в личном кинотеатре,расположенном в подвале его дома.Леди Смоллвуд нигде не видно, а посему не вполне понятно, зачем на вероятных отношениях межу этой женщиной и Майкрофтом в прошлой серии был сделан такой акцент.В середине просмотра фильм прерывается сообщением «Я вернулась».  Кто - то произносит имя Майкрофта,фильм превращается в мелькающий хаос.Майкрофт чует неладное.Он  вооружается мечом,замаскированным под зонтик.Возможность возвращения Эвр ужасает Майкрофта. «Ты же не могла сбежать из…», — бормочет брат Шерлока.Оказывается,никакого возвращения Эвр не произошло — все странности в доме Майкрофта были уловкой Шерлока,которая должна была заставить брата признать, что он скрывает существование Эвр.Оказывается,Эвр во 2 серии 4 сезона стреляла в Ватсона всего - лишь из усыпляющего пистолета.Шерлок приглашает Майкрофта на Бейкер стрит для серьезного разговора.На следующее утро Майкрофт,Шерлок и Ватсон собираются в квартире на Бейкер стрит.Майкрофт требует,чтобы Ватсон ушел,поскольку будут обсуждаться семейные дела,однако Шерлок отклоняет это требование.Майкрофт рассказывает,что Эвр с самых ранних лет была гением,превосходящим Исаака Ньютона.Однако у личности Эвр была темная сторона.Она украла любимую собаку Шерлока и не говорила никому,где ее прячет.Собаку так и не нашли.Когда она вознамерилась убить самого Шерлока,Эвр изолировали в Шерринфорде — специальной тюрьме,расположенной на острове.Майкрофт сравнил это место с адом.",
                    Tags = "Шерлок,4 сезон",
                    dateAddPost = "2017-01-14"
         
                });
            postList.Add(
                new Post
                {
                    NamePost = "2",
                    selectedCategory = "2 платы",
                    contentPost = "2",
                    Tags = "211113",
                    dateAddPost = "2017-01-134"
                });

        }
        /// <summary>
        /// Вывод имеющегося списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<Post> GetAllPost()
        {
            return postList;
        }
        /// <summary>
        /// Добавление нового товара в список
        /// </summary>
        /// <param name="model">Объект ProductModel</param>
        public void AddPost(Post model)
        {
            
            
            postList.Add(model);
        }
   
}
}