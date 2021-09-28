using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Web.ModelBinding.Attributes
{
    public class FromRquestBodyAttributes : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => throw new NotImplementedException();
    }
}
