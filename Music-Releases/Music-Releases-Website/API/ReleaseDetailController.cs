using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using Music_Releases.BL;
using Music_Releases.Repository;
using Music_Releases_Website.Classes;

namespace Music_Releases_Website.API
{
    public class ReleaseDetailController : ApiController
    {
        // GET: api/ReleaseDetail
        [Route("api/releasedetail/{asin}")]
        public IHttpActionResult Get(string asin)
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
            catch (WebException ex)
            {
                return InternalServerError();
            }

            if (musicReleaseDetailModel != null)
                return Ok(musicReleaseDetailModel);
            else
                return InternalServerError();
        }
    }
}
