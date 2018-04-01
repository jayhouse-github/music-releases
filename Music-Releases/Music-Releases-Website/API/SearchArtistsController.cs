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
        private readonly AmazonSearch _amazonSearch;

        public SearchArtistsController()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
            _amazonSearch = new AmazonSearch(amazonSearchRepo);
        }

        // GET: api/SearchArtists
        [Route("api/searchartists/{listOfBands}")]
        public IHttpActionResult Get(string listOfBands)
        {          
            var results = _amazonSearch.SearchFromCommaSeparatedList(listOfBands);

            return Ok(results);
        }
    }
}
