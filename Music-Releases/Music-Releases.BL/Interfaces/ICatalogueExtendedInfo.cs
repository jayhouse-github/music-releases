namespace Music_Releases.BL
{
    public interface ICatalogueExtendedInfo : ICatalogueInfo
    {
        string PicUrl { get; set; }
        string ReleaseDate { get; set; }
        string ASIN { get; set; }
    }
}
