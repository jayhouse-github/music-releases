using System.Collections.Generic;

namespace Music_Releases.Repository
{
    public interface IAmazonSearchRepository
    {
        IList<ICatalogueExtendedInfo> SearchAmazon(string searchTerms);     
    }
}
