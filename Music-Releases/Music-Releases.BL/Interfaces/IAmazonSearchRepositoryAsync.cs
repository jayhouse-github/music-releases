using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Releases.BL.Interfaces
{
    public interface IAmazonSearchRepositoryAsync : IAmazonSearchRepository
    {
        Task<IList<ICatalogueExtendedInfo>> SearchAmazonAsync(string searchTerms);
    }
}
