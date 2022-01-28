namespace mongodb.repository.Models;

using MongoDB.Bson.Serialization.Attributes;

public class Location
{
    [BsonElement("y")] 
    public decimal Y { get; set; }

    [BsonElement("x")]
    public decimal X { get; set; }
}