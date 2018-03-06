using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Releases.BL
{
    public class ReleaseDetailItem
    {
        string _picUrl;
        DateTime _releaseDate;
        string _asin;
        IList<SimpleItem> _items;

        public string PicUrl { get => _picUrl; set => _picUrl = value; }
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string Asin { get => _asin; set => _asin = value; }
        public IList<SimpleItem> Items { get => _items; set => _items = value; }
    }
}
