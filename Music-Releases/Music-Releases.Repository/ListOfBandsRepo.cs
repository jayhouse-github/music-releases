using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL;
using Music_Releases.BL.Interfaces;
using Music_Releases.DataObjects;

namespace Music_Releases.Repository
{
    public class ListOfBandsRepo : IListofBandsRepo
    {
        private readonly ListOfBandsContext _context;

        public ListOfBandsRepo()
        {
            _context = new ListOfBandsContext();
        }

        public string GetListOfBandsFromId(int inId)
        {
            var returnItems = _context.bandsList.FirstOrDefault(b => b.Id == inId);

            return returnItems.ListOfBands;
        }

        public int SaveNewListOfBands(string inListOfBands)
        {
            var listToAddObj = new ListOfBandsModel
            {
                ListOfBands = inListOfBands
            };

            _context.bandsList.Add(listToAddObj);
            _context.SaveChanges();

            return listToAddObj.Id;
        }
    }
}
