using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Web.RouteConfig
{
    public static class RouteConfig
    {
        public static void Register(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

            //endpoints.MapControllerRoute(
            //        name: "v1",
            //        pattern: "{controller}/{v1}/{action}/{id?}");
        }
    }
}
