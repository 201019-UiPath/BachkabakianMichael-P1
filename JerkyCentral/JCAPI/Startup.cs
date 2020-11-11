using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using JCDB.Models;
using JCDB;
using JCLib;

namespace JCAPI
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
            services.AddControllers();
            services.AddDbContext<JCContext>(options => options.UseNpgsql(Configuration.GetConnectionString("JCDB")));

            services.AddScoped<IBrandRepo, DBRepo>();
            services.AddScoped<ICartLineRepo, DBRepo>();
            services.AddScoped<ICartRepo, DBRepo>();
            services.AddScoped<ICategoryRepo, DBRepo>();
            services.AddScoped<IInventoryRepo, DBRepo>();
            services.AddScoped<ILocationRepo, DBRepo>();
            services.AddScoped<IManagerRepo, DBRepo>();
            services.AddScoped<IOrderLineRepo, DBRepo>();
            services.AddScoped<IOrderRepo, DBRepo>();
            services.AddScoped<IProductRepo, DBRepo>();
            services.AddScoped<IUserRepo, DBRepo>();

            services.AddScoped<BrandServices>();
            services.AddScoped<CartLineServices>();
            services.AddScoped<CartServices>();
            services.AddScoped<CategoryServices>();
            services.AddScoped<InventoryServices>();
            services.AddScoped<LocationServices>();
            services.AddScoped<ManagerServices>();
            services.AddScoped<OrderLineServices>();
            services.AddScoped<OrderServices>();
            services.AddScoped<ProductServices>();
            services.AddScoped<UserServices>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
