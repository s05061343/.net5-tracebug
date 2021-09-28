using Web.Request;
using Web.Validations;

namespace Web.Vaildations.Auth
{
    public class AuthRequestValidator : IAuthRequestValidator
    {
        public string FormatErrorMessage(string name) => $"{name} isn't pass {this.GetType().Name}'s validation";

        public bool IsValid(object value)
        {
            var IsValid = false;

            var model = value as AuthLoginRequest;
            IsValid = !string.IsNullOrEmpty(model.userId) && !string.IsNullOrEmpty(model.password);

            return IsValid;
        }
    }
}
