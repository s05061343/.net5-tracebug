using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Filters;
using Web.ServiceContainer;
using Web.RouteConfig;
using StackExchange.Profiling.Storage;
using System;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            /*add filters */
            services.AddMvc(configuration =>
            {
                configuration.Filters.Add(new AuthorizationFilter());
                //ExceptionFilter
                //configuration.Filters.Add(new ExceptionFilter());
                //微軟在3.0之後，開啟Endpoint，MVC不會為AllowAnonymous自動添加AllowAnonymousFilter
                configuration.EnableEndpointRouting = false;
            });
            services.AddAuthorization();


            /*add database */
            //services.AddDbContext<Model.HeroKuPostgreSQL.TomzContext>(x => x.UseNpgsql("name=ConnectionStrings:Tomz"));
            /*add httpcontext current */
            services.AddHttpContextAccessor();

            /*add service */
            DependencyResolver.InitComponents(services);

            // If using Kestrel:
            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //MiniProfiler
            //services.AddMiniProfiler(options =>
            //{
            //    options.RouteBasePath = "/profiler";
            //    //資料快取時間
            //    (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);
            //    //sql格式化設定
            //    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
            //    //跟蹤連線開啟關閉
            //    options.TrackConnectionOpenClose = true;
            //    //介面主題顏色方案;預設淺色
            //    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
            //    //.net core 3.0以上：對MVC過濾器進行分析
            //    options.EnableMvcFilterProfiling = true;
            //    //對檢視進行分析
            //    options.EnableMvcViewProfiling = true;
            //}).AddEntityFramework();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            //MiniProfiler
            //app.UseMiniProfiler();

            app.UseEndpoints(endpoints =>
            {
                RouteConfig.Register(endpoints);
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            

            //微軟在3.0之後，開啟Endpoint，MVC不會為AllowAnonymous自動添加AllowAnonymousFilter
            app.UseMvc();
        }
    }
}
