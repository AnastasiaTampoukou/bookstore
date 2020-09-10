using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class BorrowBookResponse
    {
        [DataMember(Name = "bookDetails")]
        public BookDetails BookDetails { get; set; }

    }
}
