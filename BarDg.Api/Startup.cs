using BarDg.Api.Authorizations;
using BarDg.Api.Configurations;
using BarDg.Domain.Handlers;
using BarDg.Domain.Infra.Contexts;
using BarDg.Domain.Infra.Repositories;
using BarDg.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;

namespace BarDg.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<BarDgContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("BarDg.Domain.Infra")));

            services.AddDefaultIdentity(opt =>
                {
                    opt.Password.RequiredLength = 4;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                })
                .AddDefaultRoles()
                .AddCustomEntityFrameworkStores<BarDgContext>()
                .AddDefaultTokenProviders();
            
            services.AddJwtConfiguration(Configuration, "AppSettings");
            
            services.AddSwaggerConfiguration();
            
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<OrderHandler, OrderHandler>();
            services.AddTransient<IAuthUser, AuthUser>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwaggerConfiguration();
            
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
