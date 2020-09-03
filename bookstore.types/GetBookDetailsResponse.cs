
using System.Runtime.Serialization;


namespace bookstore.types
{
    [DataContract]
    public class GetBookDetailsResponse
    {
        [DataMember(Name = "bookDetails")]
        public BookDetails BookDetails { get; set; }
    }
}
