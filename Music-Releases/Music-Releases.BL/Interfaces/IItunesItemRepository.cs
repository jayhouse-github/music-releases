namespace Music_Releases.BL
{
    public interface IItunesItemRepository
    {
        ICatalogueInfo GetInfo(string searchTerm);
    }
}
