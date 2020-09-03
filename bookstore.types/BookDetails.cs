
using System.Runtime.Serialization;


namespace bookstore.types
{
    [DataContract]
    public class BookDetails
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "shortDescription")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "statusTimestamp")]
        public string StatusTimestamp { get; set; }
    }
}
