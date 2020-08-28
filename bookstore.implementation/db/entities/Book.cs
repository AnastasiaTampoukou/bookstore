using System;

namespace bookstore.implementation.db.entities
{
    internal class Book
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? StatusTimestamp { get; set; }
    }
}