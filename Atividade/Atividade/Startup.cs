using Atividade.Data;
using Atividade.Models.Access;
using Atividade.Services;
using Atividade.Services.Buffet;
using Atividade.Services.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Atividade
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

            var connectionString = "server=localhost;user id=root;pwd=123456;database=buffetdb";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 22));

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<BuffetDbContext>(options =>
               options.UseMySql(connectionString,serverVersion)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
           );

            services.AddIdentity<User, Role>(options => 
                {
                    options.Password.RequiredLength = 2;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                }
            ).AddEntityFrameworkStores<BuffetDbContext>();

            services.ConfigureApplicationCookie(options =>
                options.LoginPath = "/Account/Login"
            );

            services.AddTransient<AccessService>();
            services.AddTransient<ClientService>();
            services.AddTransient<EventService>();
            services.AddTransient<LocalService>();
            services.AddTransient<TypeEventService>();
            services.AddTransient<GuestService>();
            services.AddTransient<GuestSituationService>();
            services.AddTransient<SituationEventService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
