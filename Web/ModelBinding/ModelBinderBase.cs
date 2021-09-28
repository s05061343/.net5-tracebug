using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace SainteirAPI.ModelBinding
{
    public abstract class ModelBinderBase : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var dbContext = (bindingContext.HttpContext.RequestServices.GetService(typeof(DbContext))) as DbContext;
                return this.BindModelAsync(bindingContext, dbContext);
            }
            catch (Exception ex)
            {
                /*
                 * 如果程式不幸進入這裡，請檢查Request是否有"必填參數未傳或"參數必填屬性設定錯誤"
                 */
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
                throw ex;

            }
        }

        protected abstract Task BindModelAsync(ModelBindingContext bindingContext, DbContext dbContext);
    }
}