using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Web.ModelBinding.Attributes;

namespace SainteirAPI.ModelBinding
{
    public static class ModelBindingExtension
    {
        public static int GetInt(this IModelBinder modelBinder, string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }

        public static T BindModelFromBody<T>(this IModelBinder modelBinder, ModelBindingContext bindingContext) =>
            (T)new RequestBodyBinding().BindClassType(typeof(T), bindingContext.HttpContext);

        public static IEnumerable<T> SplitParameters<T>(this IModelBinder modelBinder, string nativeParam, Func<object, T> covertExpression, params char[] separator)
        {
            if (string.IsNullOrEmpty(nativeParam))
            {
                throw new InvalidCastException();
            }
            return nativeParam
                .Split(separator)
                .Select(x => covertExpression(x)) as IEnumerable<T>;
        }

        public static IEnumerable<int> SplitParameters(this IModelBinder modelBinder, string str, params char[] separator)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    throw new InvalidCastException();
                }
                return str.Split(separator).Select(x => Convert.ToInt32(x));
            }
            catch
            {
                return new List<int>();
            }
        }

        public static List<IFormFile> ProccessFile(this IModelBinder modelBinder, IFormFileCollection fileCollection)
        {
            var res = new List<IFormFile>();
            foreach (var fileRow in fileCollection)
            {
                res.Add(fileRow);
            }
            return res;
        }

        public static IEnumerable<(string filename, Stream content)> ProccessFileArray(this IModelBinder modelBinder, IEnumerable<IFormFile> fileCollection)
        {
            foreach (var file in fileCollection)
            {
                yield return ((file.FileName, file.OpenReadStream()));
            }
        }


        public static (string name, Stream content) GetFile(this IModelBinder modelBinder, string index, HttpContextAccessor contextAccessor)
        {
            var fileCollection = contextAccessor.HttpContext.Request.Form.Files;
            var postedFile = fileCollection[index];
            return (postedFile.FileName, postedFile.OpenReadStream());
        }
    }
}