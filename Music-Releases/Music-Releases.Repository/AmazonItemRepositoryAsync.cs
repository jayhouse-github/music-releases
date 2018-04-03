using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL;
using Music_Releases.BL.Interfaces;

namespace Music_Releases.Repository
{
    public class AmazonItemRepositoryAsync : AmazonItemRepository, IAmazonItemRepositoryAsync
    {
        public AmazonItemRepositoryAsync(string accessId, string requestEndPoint, string associateTag, string secretKey) : base(accessId, requestEndPoint, associateTag, secretKey)
        {
        }

        public Task<ICatalogueExtendedInfo> LookupASINAsync(string ASINNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ICatalogueExtendedInfo> LookupSearchStringAsync(string searchString, SearchIndex searchIndex)
        {
            throw new NotImplementedException();
        }

        
    }
}
