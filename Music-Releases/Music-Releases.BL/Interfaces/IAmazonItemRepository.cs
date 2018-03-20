namespace Music_Releases.BL
{
    public interface IAmazonItemRepository
    {
        ICatalogueExtendedInfo LookupASIN(string ASINNumber);
        ICatalogueExtendedInfo LookupSearchString(string searchString, SearchIndex searchIndex);
    }
}
