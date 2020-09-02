namespace LaundryBooker.Web
{
    using DataLayer.Repository;
    using Engine.Services;
    using Microsoft.Extensions.Configuration;
    using DataLayer.Database.DatabaseContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBookingSessionService, BookingSessionService>();
            services.AddTransient<IBookingSessionRepository, BookingSessionRepository>();
            services.AddControllersWithViews();

            services.AddDbContext<LaundryContext>(config =>
                config.UseSqlServer(_configuration.GetConnectionString("LaundryBookerDatabase")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}