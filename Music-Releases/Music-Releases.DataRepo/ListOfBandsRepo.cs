using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.DataObjects;
using System.Data.Entity;
using Music_Releases.BL;

namespace Music_Releases.DataRepo
{
    public class ListOfBandsRepo
    {
        private ListOfBandsContext BandsList { get; set; }

        public ListOfBandsRepo()
        {
            BandsList = new Music_Releases.DataObjects.ListOfBandsContext();
        }

        public int SaveNewListOfBands(string inListOfBands)
        {
            var newList = new ListOfBandsModel
            {
                ListOfBands = inListOfBands
            };

            BandsList.bandsList.Add(newList);
        }
    }
}
