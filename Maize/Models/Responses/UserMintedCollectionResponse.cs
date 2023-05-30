namespace Maize.Models.Responses
{
    public class CollectionMinted
    {
        public CollectionInformation collection { get; set; }
    }
    public class UserMintedCollectionResponse
    {
        public List<CollectionMinted> collections { get; set; }
        public int totalNum { get; set; }
    }
}


