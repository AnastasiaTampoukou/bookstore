using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class BorrowBookRequest
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }

        [DataMember(Name = "status")]
        public string Status = "Borrowed";
    }
}
