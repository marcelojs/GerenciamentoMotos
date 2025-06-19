namespace WebApiGerenciamentoMotos.ViewModel
{
    public class RentViewModel
    {
        public string RentId { get; set; }
        public string MotorcycleId { get; set; }
        public string DeliveryManId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PrevisionFinish { get; set; }
        public int Plan { get; set; }
    }
}
