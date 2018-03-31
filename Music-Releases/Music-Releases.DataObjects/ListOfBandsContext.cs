using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL;
using System.Data.Entity;

namespace Music_Releases.DataObjects
{
    public class ListOfBandsContext : DbContext
    {
        public ListOfBandsContext() : base("DefaultConnection"){}

        public DbSet<ListOfBandsModel> bandsList { get; set; }
    }
}
