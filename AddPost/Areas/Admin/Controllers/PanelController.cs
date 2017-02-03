using AddPost.Controllers;
using AddPost.Filters;
using AddPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace AddPost.Areas.Admin.Controllers
{
    public class PanelController : BaseController
    {
        [CustomAuthAttribute]
        public ActionResult ChooseEditPost()
        {
            return View(PostDataStorage.Storage.GetAllPost().OrderByDescending(x => x.dateAddPost));
        }
    }
}
