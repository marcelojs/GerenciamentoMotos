namespace WebApiGerenciamentoMotos.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            this.IsValid = true;
            this.Errors = new List<string>();
        }

        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }

        public void AddMessageError(string messageError)
        { 
            IsValid = false;
            Errors.Add(messageError);
        }
    }
}
