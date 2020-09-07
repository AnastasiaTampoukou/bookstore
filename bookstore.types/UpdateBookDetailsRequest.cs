using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class UpdateBookDetailsRequest
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
