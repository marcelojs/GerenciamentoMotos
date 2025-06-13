namespace WebApiGerenciamentoMotos.Models
{
    public class Rent
    {
        public Guid Id { get; set; }
        public Guid MotorcycleId { get; set; }
        public Guid DeliveryManId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PrevisionFinish { get; set; }
        public int Plan { get; set; }

        public void SetExtraDay()
        {
            if(StartDate.HasValue)
                StartDate.Value.AddDays(1);
        }

        public bool AllDatesIsValid()
        { 
            if (StartDate.HasValue && EndDate.HasValue && PrevisionFinish.HasValue)
                return true;
            
            return false;
        }
    }
}
