using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SainteirAPI.ModelBinding;
using System.Threading.Tasks;
using Web.Request;

namespace Web.ModelBinding.Auth
{
    public class AuthQuseryBinder : ModelBinderBase, IModelBinder
    {
        protected override Task BindModelAsync(ModelBindingContext bindingContext, DbContext dbContext)
        {
            var model = this.BindModelFromBody<AuthLoginRequest>(bindingContext);
            var formFiles = bindingContext.HttpContext.Request.Form.Files;
            model.imageset = this.ProccessFile(formFiles);
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
