namespace Music_Releases.Repository
{
    public interface ICatalogueExtendedInfo : ICatalogueInfo
    {
        string PicUrl { get; set; }
        string ReleaseDate { get; set; }
        string ASIN { get; set; }
    }
}
