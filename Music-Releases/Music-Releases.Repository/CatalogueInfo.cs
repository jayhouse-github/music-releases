﻿using Music_Releases.BL;

namespace Music_Releases.Repository
{
    class CatalogueInfo : ICatalogueInfo
    {
        private string _artist;
        private string _title;
        private string _url;
        private int _price;

        public string Artist { get => _artist; set => _artist = value; }
        public string Title { get => _title; set => _title = value; }
        public string Url { get => _url; set => _url = value; }
        public int Price { get => _price; set => _price = value; }
    }
}
