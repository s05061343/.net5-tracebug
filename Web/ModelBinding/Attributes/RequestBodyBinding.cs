using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ModelBinding.Attributes
{
    public class RequestBodyBinding : IModelBinder
    {
        public RequestBodyBinding()
        {

        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            object result;
            var paramName = bindingContext.FieldName;
            var paramType = bindingContext.ModelType;
            var httpContext = bindingContext.HttpContext;
            if (paramType.IsClass && paramType.Name != typeof(String).Name)
            {
                result = this.BindClassType(paramType, httpContext);
            }
            else
            {
                result = this.BindNativeType(paramType, httpContext, paramName);
            }
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }

        public virtual object BindClassType(Type type, HttpContext httpContext)
        {
            var value = Activator.CreateInstance(type);
            var props = type.GetProperties().ToList();
            object raw;

            if (httpContext.Request.ContentType.Contains("application/json"))
            {
                raw = new StreamReader(httpContext.Request.Body).ReadToEndAsync().Result;
            }
            else
            {
                raw = httpContext.Request.Form;
            }

            props.ForEach(prop =>
            {
                var propName = prop.Name;
                var propType = prop.PropertyType;
                var propValue = string.Empty;
                try
                {
                    if (httpContext.Request.ContentType.Contains("application/json"))
                    {
                        propValue = JObject.Parse(raw as string)[propName].ToString();
                    }
                    else
                    {
                        propValue = (raw as IFormCollection)[propName];
                    }
                }
                catch (NullReferenceException) 
                {
                    propValue = null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"BindClassType throw Exception : [{ex}]");
                    //propValue = null;
                }

                var propVal = Convert.ChangeType(propValue, propType);
                prop.SetValue(value, propVal);
            });
            return value;
        }

        public virtual object BindNativeType(Type type, HttpContext httpContext, string name)
        {
            try
            {
                var rawValue = string.Empty;
                if (httpContext.Request.ContentType.Contains("application/json"))
                {
                    var result = new StreamReader(httpContext.Request.Body).ReadToEndAsync().Result;
                    rawValue = JObject.Parse(result)[name].ToString();
                }
                else
                {
                    rawValue = httpContext.Request.Form[name];
                }
                var converter = TypeDescriptor.GetConverter(type);
                var propVal = converter.ConvertFromString(rawValue);
                return propVal;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"BindNativeType throw Exception : [{ex}]");
                //return null;
            }
        }


    }
}
