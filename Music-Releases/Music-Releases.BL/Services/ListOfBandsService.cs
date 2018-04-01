using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL.Interfaces;

namespace Music_Releases.BL.Services
{
    public class ListOfBandsService
    {
        private IListofBandsRepo _repo;

        public ListOfBandsService(IListofBandsRepo repo)
        {
            _repo = repo;
        }

        public int SaveNewList(string inList)
        {
            return _repo.SaveNewListOfBands(inList);
        }

        public string GetBandsFromId(int inId)
        {
            return _repo.GetListOfBandsFromId(inId);
        }
    }
}
