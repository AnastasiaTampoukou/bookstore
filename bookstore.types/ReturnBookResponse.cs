using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class ReturnBookResponse
    {
        [DataMember(Name = "bookDetails")]
        public BookDetails BookDetails { get; set; }
    }
}
