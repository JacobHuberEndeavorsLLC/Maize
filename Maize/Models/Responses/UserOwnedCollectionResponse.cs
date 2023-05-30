namespace Maize.Models.Responses
{    
    public class CollectionOwned
    {
        public CollectionInformation collection { get; set; }
        public int count { get; set; }
    }
    public class UserOwnedCollectionResponse
    {
        public List<CollectionOwned> collections { get; set; }
        public int totalNum { get; set; }
    }


}


