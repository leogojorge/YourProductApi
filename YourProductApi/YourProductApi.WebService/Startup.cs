using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourProductApi.Application;
using YourProductApi.Application.ProductServices;
using YourProductApi.AutoMapperCore;
using YourProductApi.AutoMapperCore.Mappers;
using YourProductApi.Domain.IRepositories;
using YourProductApi.Domain.Sevices;
using YourProductApi.Domain.Sevices.Validator;
using YourProductApi.Infrastructure;
using YourProductApi.Infrastructure.Data;

namespace YourProductApi.WebService
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
            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped<IMongoContext, MongoContext>();

            services.AddTransient<IValidator, ProductValidator>();

            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ISaveProductServices, SaveProductServices>();
            services.AddTransient<IGetProductServices, GetProductServices>();
            
            services.AddScoped<IMapperCore, MapperCore>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            }
    }
}
