using System.Collections.Generic;
using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class GetAllBooksResponse
    {
        [DataMember(Name = "books")]
        public List<BookShortDetails> Books { get; set; }
    }
}