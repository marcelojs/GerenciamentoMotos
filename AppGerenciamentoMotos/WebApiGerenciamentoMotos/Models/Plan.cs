using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiGerenciamentoMotos.Models
{
    public class Plan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("days")]
        public int Days { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}
