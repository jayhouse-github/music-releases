namespace Music_Releases.Repository
{
    public interface ICatalogueInfo
    {
        string Artist { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        int Price { get; set; }
    }
}
