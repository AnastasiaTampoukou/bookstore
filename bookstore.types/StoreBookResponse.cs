using System.Runtime.Serialization;


namespace bookstore.types
{
    [DataContract]
    public class StoreBookResponse
    {
        [DataMember(Name = "bookDetails")]
        public BookDetails BookDetails { get; set; }
    }
}
