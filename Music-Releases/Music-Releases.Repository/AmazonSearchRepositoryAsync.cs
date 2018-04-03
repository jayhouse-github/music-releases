using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL;
using Music_Releases.BL.Interfaces;

namespace Music_Releases.Repository
{
    public class AmazonSearchRepositoryAsync : AmazonSearchRepository, IAmazonSearchRepositoryAsync
    {
        public AmazonSearchRepositoryAsync(string accessId, string requestEndPoint, string associateTag, string secretKey) : base(accessId, requestEndPoint, associateTag, secretKey)
        {
        }

        public Task<IList<ICatalogueExtendedInfo>> SearchAmazonAsync(string searchTerms)
        {
            throw new NotImplementedException();
        }       
    }
}
