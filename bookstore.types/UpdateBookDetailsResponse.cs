using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class UpdateBookDetailsResponse
    {
        [DataMember(Name = "bookDetails")]
        public BookDetails BookDetails { get; set; }
    }
}
