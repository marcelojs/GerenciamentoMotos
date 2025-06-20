using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApiGerenciamentoMotos.Models
{
    public class DeliveryMan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("deliveryManId")]
        public string DeliveryManId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("cnpj")]
        public string CNPJ { get; set; }

        [BsonElement("birthdayDate")]
        public DateTime BirthdayDate { get; set; }

        [BsonElement("cnhNumber")]
        public string CNHNumber { get; set; }

        [BsonElement("cnhType")]
        public string CNHType { get; set; }

        [BsonElement("cnhImageName")]
        public string CNHImageName { get; set; }

        public bool CNHIsValidForRent()
        {
            bool cnhIsValid = false;
            foreach (var type in CNHType)
            {
                if (type == 'A')
                    cnhIsValid = true;
            }

            return cnhIsValid;
        }

        public bool CNHIsValid()
        {
            if (CNHType == "A") return true;
            if (CNHType == "B") return true;
            if (CNHType == "AB") return true;

            return false;
        }

        public void NewId()
        {
            DeliveryManId = Guid.NewGuid().ToString();
        }
    }
}


