
using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class RemoveBookResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

    }
}
