namespace WebApiGerenciamentoMotos.Models
{
    public class DeliveryMan
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public DateTime BirthdayDate { get; set; }

        public string CNHNumber { get; set; }

        public string CNHType { get; set; }

        public string CNHImageName { get; set; }

        public bool CNHIsValidForRent()
        {
            bool cnhIsValid = false;
            foreach (var type in CNHType)
            {
                if (type == 'A')
                {
                    cnhIsValid = true;
                    continue;
                }
            }

            return cnhIsValid;
        }
    }
}


