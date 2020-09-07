
using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class RemoveBookRequest
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }
    }
}
