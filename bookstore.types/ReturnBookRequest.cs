using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class ReturnBookRequest
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }
    }
}
