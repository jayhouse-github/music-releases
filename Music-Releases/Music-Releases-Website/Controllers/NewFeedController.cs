using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music_Releases_Website.Models;
using Ninject;
using Music_Releases_Website.Classes;
using Music_Releases.Repository;
using Music_Releases.BL;

namespace Music_Releases_Website.Controllers
{
    public class NewFeedController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SearchBandsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Create entry in DB and forward to view containing url of RSS feed
                //Temp
                return View();
            }
            else
                return View(model);
        }
    }
}
