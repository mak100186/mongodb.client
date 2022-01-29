namespace mongodb.repository.Models
{
    using Contracts;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Log : ICollectionItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("hostname")] 
        public string HostName { get; set; } = null!;

        [BsonElement("pid")] 
        public int? ProcessId { get; set; } = null!;
    }
}