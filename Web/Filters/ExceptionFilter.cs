using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = new JsonResult(new
            {
                By = "Tom",
                Result = false,
                Code = 500,
                Message = context.Exception.Message
            });
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
