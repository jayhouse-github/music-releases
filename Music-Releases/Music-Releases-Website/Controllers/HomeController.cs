using System;
using System.Linq;
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
        private readonly AmazonSearch _amazonSearch;
        private readonly ReleaseSearch _releaseSearch;

        public HomeController()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();

            _releaseSearch = new ReleaseSearch(amazonItemRepo, itunesItemRepo);
            _amazonSearch = new AmazonSearch(amazonSearchRepo);
        }

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
                    var results = _amazonSearch.SearchFromCommaSeparatedList(bandsModel.ListOfBands);

                    return View("~/Views/Search/Results.cshtml", results.ToList());
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
            MusicReleaseCollection musicReleaseDetailModel = null;

            try
            {
                musicReleaseDetailModel = _releaseSearch.GetDetails(asin);
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