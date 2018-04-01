using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Music_Releases_Website.Classes;
using Music_Releases.BL;
using Music_Releases.BL.Services;
using Music_Releases.BL.Interfaces;

namespace Music_Releases_Website.Controllers
{
    public class FeedController : Controller
    {
        private readonly ListOfBandsService _service;
        private readonly AmazonSearch _amazonSearch;

        public FeedController()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var listOfBandsRepo = kernal.Get<IListofBandsRepo>();
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            _service = new ListOfBandsService(listOfBandsRepo);
            _amazonSearch = new AmazonSearch(amazonSearchRepo);
        }

        // GET: Feed
        [HandleError]
        public ActionResult Index(int id)
        {
            var bands = _service.GetBandsFromId(id);

            if (bands != null)
            {
                var results = _amazonSearch.SearchFromCommaSeparatedList(bands);

                return RssResult(results.ToList());
            }

            return null;
        }

        private RssResult RssResult(List<ExtendedItem> feedItems)
        {
            return new RssResult(feedItems, "New music releases");
        }
    }
}