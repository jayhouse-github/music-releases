using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Music_Releases.BL;

namespace Music_Releases.DataModel
{
    public class MusicReleasesContext : DbContext
    {
        public DbSet<ListOfBandsModel> Feeds { get; set; }
    }
}
