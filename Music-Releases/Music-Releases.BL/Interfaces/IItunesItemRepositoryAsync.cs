using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Releases.BL.Interfaces
{
    public interface IItunesItemRepositoryAsync : IItunesItemRepository
    {
        Task<ICatalogueInfo> GetInfoAsync(string searchTerm);
    }
}
