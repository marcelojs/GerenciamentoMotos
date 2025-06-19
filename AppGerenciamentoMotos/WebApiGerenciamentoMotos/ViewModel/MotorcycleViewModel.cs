using MongoDB.Bson.Serialization.Attributes;

namespace WebApiGerenciamentoMotos.ViewModel
{
    public class MotorcycleViewModel
    {
        public string MotorcycleId { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
