namespace Music_Releases.BL
{
    public interface ICatalogueInfo
    {
        string Artist { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        int Price { get; set; }
    }
}
