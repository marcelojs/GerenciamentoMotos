namespace WebApiGerenciamentoMotos.Service
{
    public class ServiceBase
    {
        public bool FieldIsValid(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
