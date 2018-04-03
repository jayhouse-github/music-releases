using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Releases.BL.Interfaces
{
    public interface IAmazonItemRepositoryAsync : IAmazonItemRepository
    {
        Task<ICatalogueExtendedInfo> LookupASINAsync(string ASINNumber);
        Task<ICatalogueExtendedInfo> LookupSearchStringAsync(string searchString, SearchIndex searchIndex);
    }
}
