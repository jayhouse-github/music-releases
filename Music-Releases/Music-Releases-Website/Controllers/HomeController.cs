using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Music_Releases.BL;
using Music_Releases_Website.Classes;
using Music_Releases_Website.Models;
using System.Net;

namespace Music_Releases_Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // POST: Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SearchBandsViewModel bandsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IKernel kernal = new StandardKernel(new BindModule());
                    var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
                    var amazonSearch = new AmazonSearch(amazonSearchRepo);
                    var results = amazonSearch.SearchFromCommaSeparatedList(bandsModel.ListOfBands);

                    return View("~/Views/Search/Results.cshtml", results);
                }
                else
                {
                    return View(bandsModel);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Detail(string asin)
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();
            var releaseSearch = new ReleaseSearch(amazonItemRepo, itunesItemRepo);
            MusicReleaseCollection musicReleaseDetailModel = null;

            try
            {
                musicReleaseDetailModel = releaseSearch.GetDetails(asin);
            }
            catch(WebException ex)
            {
                return RedirectToAction("Index", "Error");
            }

            if(musicReleaseDetailModel != null)
                return View(musicReleaseDetailModel);
            else
                return RedirectToAction("Index", "Error");
        }
    }
}