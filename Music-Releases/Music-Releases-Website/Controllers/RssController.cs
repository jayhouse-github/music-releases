using System.Web.Mvc;

namespace Music_Releases_Website.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        public ActionResult Index()
        {
            return View();
        }
    }
}