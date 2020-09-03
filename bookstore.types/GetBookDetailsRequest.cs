
using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class GetBookDetailsRequest
    {
        [DataMember(Name ="bookId")]
        public string BookId { get; set; }
    }
}
