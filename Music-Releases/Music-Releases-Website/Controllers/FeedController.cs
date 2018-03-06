using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Music_Releases.Repository;
using Music_Releases_Website.Classes;
using Music_Releases.BL;

namespace Music_Releases_Website.Controllers
{
    public class FeedController : Controller
    {

        // GET: Feed
        [HandleError]
        public ActionResult Index(int id)
        {
            string bands = "";

            //Access DB for bands in DB entry
            //Temp
            if (id == 3)
                bands = "ride,the cure,depeche mode";

            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            var amazonSearch = new AmazonSearch(amazonSearchRepo);

            var results = amazonSearch.SearchFromCommaSeparatedList(bands);

            return RssResult(results.ToList());
        }

        private RssResult RssResult(List<ExtendedItem> feedItems)
        {
            return new RssResult(feedItems, "New music releases");
        }
    }
}