using System.Runtime.Serialization;

namespace bookstore.types
{
    [DataContract]
    public class DatabaseStatus
    {
        [DataMember(Name = "statusMessage")]
        public string StatusMessage { get; set; }
    }
}