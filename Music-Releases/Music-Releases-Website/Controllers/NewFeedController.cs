using System.Web.Mvc;
using Music_Releases_Website.Models;
using Ninject;
using Music_Releases_Website.Classes;
using Music_Releases.BL.Interfaces;
using Music_Releases.BL.Services;

namespace Music_Releases_Website.Controllers
{
    public class NewFeedController : Controller
    {
        private ListOfBandsService _service;

        public NewFeedController()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var listOfBandsRepo = kernal.Get<IListofBandsRepo>();
            _service = new ListOfBandsService(listOfBandsRepo);
        }

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
                var newId = _service.SaveNewList(model.ListOfBands);
                ViewBag.NewID = newId;

                return View();
            }
            else
                return View(model);
        }
    }
}
