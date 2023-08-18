using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CardsApi.Models;

public class Card
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("question")]
    public string Question { get; set; } = null!;

    [BsonElement("answer")]
    public int Answer { get; set; }

}