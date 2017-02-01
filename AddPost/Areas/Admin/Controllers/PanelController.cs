using AddPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddPost.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        [Authorize(Roles ="admin")]
        public ActionResult EditPost(int id)
        {

            return View(PostDataStorage.Storage.GetPostById(id));
        }
    }
}