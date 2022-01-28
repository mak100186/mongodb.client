namespace mongodb.repository.Models;

using Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
    
public class Zip : ICollectionItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("city")]
    public string City { get; set; } = null!;

    [BsonElement("zip")]
    public int? ZipCode { get; set; } = null!;

    [BsonElement("pop")]
    public int? Population { get; set; } = null!;

    [BsonElement("state")]
    public string State { get; set; } = null!;

    [BsonElement("loc")]
    public Location Location { get; set; } = null!;
}