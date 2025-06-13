using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Response
{
    public class ResponseWrapper
    {
        public ResponseWrapper(ValidationResult validationResult, decimal value)
        {
            ValidationResult = new ValidationResult();
            FinalValue = value;
        }

        public ValidationResult ValidationResult { get; set; }

        public decimal FinalValue { get; set; }
    }
}
