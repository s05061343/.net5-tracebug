namespace Web.Validations
{
    public interface IValidator
    {
        bool IsValid(object value);
        string FormatErrorMessage(string name);
    }
}