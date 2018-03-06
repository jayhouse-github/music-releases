using System;
using System.Collections.Generic;
using System.Linq;
namespace Music_Releases.Repository
{
    class CatalogueExtendedInfo : CatalogueInfo, ICatalogueExtendedInfo
    {
        private string _picUrl;
        private string _releaseDate;
        private string _asin;

        public string PicUrl { get => _picUrl; set => _picUrl = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string ASIN { get => _asin; set => _asin = value; }
    }
}
