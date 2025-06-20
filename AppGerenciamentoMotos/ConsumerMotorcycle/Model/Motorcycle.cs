using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsumerMotorcycle.Model
{
    public class Motorcycle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("motorcycleId")]
        public string MotorcycleId { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("plate")]
        public string Plate { get; set; }

        public void NewId()
        {
            var temporaryId = Guid.NewGuid().ToString("D").Split('-');
            var field1 = temporaryId[0];
            var field2 = temporaryId[1];

            MotorcycleId = $"{field1}-{field2}-{Plate}-{Year}".ToLower();
        }

        public bool MotorcycleIsValid()
        {
            var resultModel = FieldIsValid(Model);
            var resultPlate = FieldIsValid(Plate);

            if(Year == 0 || resultModel || resultPlate)
                return false;

            return true;
        }

        private bool FieldIsValid(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
