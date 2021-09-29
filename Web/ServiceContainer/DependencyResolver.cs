using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Auth;
using Service.Auth.Token;
using Service.TaskForm;
using Web.Filters;
using Web.Vaildations.Auth;

namespace Web.ServiceContainer
{
    public static class DependencyResolver
    {
        public static ServiceProvider Services { get; private set; }
        public static void InitComponents(IServiceCollection services)
        {
            DependencyResolver.InitDbContext(services);
            DependencyResolver.InitService(services);
            DependencyResolver.InitValidator(services);
            Services = services.BuildServiceProvider();
        }

        private static void InitDbContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, Model.Sqlite.SQLiteContext>();
        }

        private static void InitService(IServiceCollection services)
        {
            services.AddScoped<IAuthManager, AuthManager<JWT>>();
            services.AddScoped<JWT>();
            services.AddScoped<AuthorizationFilter>();
            services.AddScoped<ExceptionFilter>();
            services.AddScoped<ITaskFormService, TaskFormService>();
        }

        private static void InitValidator(IServiceCollection services)
        {
            services.AddScoped<IAuthRequestValidator, AuthRequestValidator>();
        }
    }
}
