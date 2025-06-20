using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiGerenciamentoMotos.Models
{
    public class Rent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("rentId")]
        public string RentId { get; set; }

        [BsonElement("motorcycleId")]
        public string MotorcycleId { get; set; }

        [BsonElement("deliveryManId")]
        public string DeliveryManId { get; set; }

        [BsonElement("startDate")]
        public DateTime? StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime? EndDate { get; set; }

        [BsonElement("previsionFinish")]
        public DateTime? PrevisionFinish { get; set; }

        [BsonElement("plan")]
        public int Plan { get; set; }

        public void SetExtraDay()
        {
            if(StartDate.HasValue)
                StartDate = StartDate.Value.AddDays(1);
        }

        public bool AllDatesIsValid()
        { 
            if (StartDate.HasValue && EndDate.HasValue && PrevisionFinish.HasValue)
                return true;
            
            return false;
        }

        public void NewId()
        { 
            RentId = Guid.NewGuid().ToString();
        }

        //Uma data de cadastro seria interessante ter tbm para ter a data do registro pois o negócio pede para que a data de inicio seja um dia a mais após o cadastro
    }
}
