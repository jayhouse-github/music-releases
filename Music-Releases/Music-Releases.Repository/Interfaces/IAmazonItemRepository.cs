namespace Music_Releases.Repository
{
    public interface IAmazonItemRepository
    {
        ICatalogueExtendedInfo LookupASIN(string ASINNumber);
        ICatalogueExtendedInfo LookupSearchString(string searchString, SearchIndex searchIndex);
    }
}
