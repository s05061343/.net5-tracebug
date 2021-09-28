using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using Web.ServiceContainer;
using Web.Validations;

namespace SainteirAPI.Validations
{
    public class ValidateRequestAttribute : ValidationAttribute
    {
        public Type Validator { get; set; }
        protected IValidator _validator;
        //protected readonly IServiceProvider _provider;
        //public ValidateRequestAttribute(IServiceProvider provider)
        //{
        //    _provider = provider;
        //}

        public ValidateRequestAttribute()
        {

        }

        public ValidateRequestAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public ValidateRequestAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        protected virtual IValidator GetValidator()
        {
            if (this._validator == null)
            {
                this._validator = DependencyResolver.Services.GetService(this.Validator) as IValidator;
            }
            return this._validator;
        }
        public override string FormatErrorMessage(string name) => this.GetValidator().FormatErrorMessage(name);
        public override bool IsValid(object value) => this.GetValidator().IsValid(value);

    }
}