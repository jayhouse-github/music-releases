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
    public class SearchArtistsController : ApiController
    {
        // GET: api/SearchArtists
        [Route("api/searchartists/{listOfBands}")]
        public IHttpActionResult Get(string listOfBands)
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
            var amazonSearch = new AmazonSearch(amazonSearchRepo);
            var results = amazonSearch.SearchFromCommaSeparatedList(listOfBands);

            return Ok(results);
        }
    }
}
