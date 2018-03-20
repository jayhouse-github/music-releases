using System.Collections.Generic;

namespace Music_Releases.BL
{
    public interface IAmazonSearchRepository
    {
        IList<ICatalogueExtendedInfo> SearchAmazon(string searchTerms);     
    }
}
