namespace Music_Releases.Repository
{
    public interface IItunesItemRepository
    {
        ICatalogueInfo GetInfo(string searchTerm);
    }
}
