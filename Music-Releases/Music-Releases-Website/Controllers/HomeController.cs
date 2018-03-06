using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Music_Releases.Repository;
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

        // POST: Search/Create
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
            ReleaseDetailItem releaseDetail = null;

            if (asin != null)
            {
                try
                {
                    releaseDetail = new ReleaseDetails(amazonItemRepo, itunesItemRepo).GetReleaseDetailsFromASIN(asin);
                }
                catch (WebException ex)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            var amazonCDItem = releaseDetail.Items.Where(i => i.Source.ToLower() == "amazoncd").FirstOrDefault();
            var amazonMP3Item = releaseDetail.Items.Where(i => i.Source.ToLower() == "amazonmp3").FirstOrDefault();
            var itunesItem = releaseDetail.Items.Where(i => i.Source.ToLower() == "itunes").FirstOrDefault();

            if (amazonCDItem == null && amazonMP3Item == null && itunesItem == null)
            {
                return RedirectToAction("Index", "Error");
            }

            var musicReleaseDetailModel = new MusicReleaseCollection
            {
                PicUrl = releaseDetail.PicUrl,
                ReleaseDate = releaseDetail.ReleaseDate,
                Asin = releaseDetail.Asin,
                AmazonCD = amazonCDItem,
                AmazonMP3 = amazonMP3Item,
                ITunes = itunesItem
            };

            if (amazonCDItem != null)
            {
                musicReleaseDetailModel.Artist = amazonCDItem.Artist;
                musicReleaseDetailModel.Title = amazonCDItem.Title;
            }
            else if (amazonMP3Item != null)
            {
                amazonMP3Item.Artist = amazonCDItem.Artist;
                amazonMP3Item.Title = amazonCDItem.Title;
            }
            else if (itunesItem != null)
            {
                itunesItem.Artist = amazonCDItem.Artist;
                itunesItem.Title = amazonCDItem.Title;
            }

            return View(musicReleaseDetailModel);
        }
    }
}