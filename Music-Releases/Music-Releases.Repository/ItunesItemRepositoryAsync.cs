using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Music_Releases.BL;
using Music_Releases.BL.Interfaces;
using Music_Releases.Repository.Helpers;
using Newtonsoft.Json;

namespace Music_Releases.Repository
{
    class ItunesItemRepositoryAsync : ItunesItemRepository, IItunesItemRepositoryAsync
    {
        public ItunesItemRepositoryAsync(string affiliateId, string requestUrl) : base(affiliateId, requestUrl)
        {
        }

        public async Task<ICatalogueInfo> GetInfoAsync(string searchTerm)
        {
            var keywords = HttpUtility.UrlEncode(searchTerm);
            string returnedData;
            ICatalogueInfo returnItem = new CatalogueInfo();

            var requestURL = String.Format(_requestUrl + "?term={0}&country=GB&entity=album", keywords);

            using (var client = new WebClient())
            {
                returnedData = client.DownloadString(requestURL);
            }

            //var dataObj = await JsonConvert.DeserializeObjectAsync<ItunesItemCollection>(returnedData);
            var dataObj = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ItunesItemCollection>(returnedData));

            if (dataObj.Result.ResultCount > 0)
                returnItem = ItunesHelper.GetNewCatalogueObjectFromItunesObject(dataObj.Result.Results.First());
            else
                returnItem = null;

            return returnItem;
        }
    }
}
