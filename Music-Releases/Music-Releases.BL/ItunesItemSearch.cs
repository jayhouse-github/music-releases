using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Releases.BL
{
    public class ItunesItemSearch
    {
        IItunesItemRepository _repo;

        public ItunesItemSearch(IItunesItemRepository inRepo)
        {
            _repo = inRepo;
        }

        public SimpleItem GetBySearchTerm(string inSearchTerm)
        {
            var returnedItem = _repo.GetInfo(inSearchTerm);

            if (returnedItem == null)
                return null;

            return new SimpleItem {
                Artist = returnedItem.Artist,
                Title = returnedItem.Title,
                Url = returnedItem.Url,
                Price = Convert.ToDecimal(returnedItem.Price) / 100
            };
        }
    }
}
