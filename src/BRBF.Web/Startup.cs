using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BRBF.Core.Business.RegisteredBusiness;
using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using BRBF.Core.Framework.RequestPipeline.Behaviors;
using BRBF.DataAccess;
using BRBF.DataAccess.Repositories;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace src
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
            // Add framework services.
            services.AddMvc();

            // Entity Framework
            services
                .AddDbContext<BatonRougeBusinessFinderDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbContext")));

            // add Mediatr
            var assemblies = new List<Assembly>
            {
                typeof(RequestRunner).GetTypeInfo().Assembly
            };
            services.AddMediatR(assemblies);
            // Request Pipeline Behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            //serviceCollection.AddSingleton(typeof(IRequestPreProcessor<>), typeof(LoggingBehavior<,>));
            //serviceCollection.AddTransient(typeof(IRequestPostProcessor<,>), typeof(LoggingBehavior<,>));

            // Additional Services
            services.AddTransient<IRequestHandlerTypeProvider, RequestHandlerTypeProvider>();
            services.AddTransient<IRequestRunner, RequestRunner>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRegisteredBusinessRepository, RegisteredBusinessRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
