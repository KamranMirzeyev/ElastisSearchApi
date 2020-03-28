using AutoMapper;
using Core;
using Core.Repositories;
using Core.Services.Data;
using Core.Services.Rest;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.CloudinaryService;
using Services.Data;

namespace ElasticSearch
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
            // services.AddDbContext<DataContext>(options =>
            //     options.UseNpgsql(Configuration.GetConnectionString("Default"),
            //     x => x.MigrationsAssembly("Data")));

            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt =>
        opt.UseNpgsql(Configuration.GetConnectionString("Default"),x=>x.MigrationsAssembly("Data")));

            services.AddControllers();
            services.AddCors();

            services.AddAutoMapper(typeof(Startup));

          

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductServices, ProductService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<ISearchProvider, SearchProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
