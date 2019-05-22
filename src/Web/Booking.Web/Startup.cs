namespace Booking.Web
{
    using Booking.Common;
    using Booking.Data;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Data.Repositories;
    using Booking.Data.Seeding;
    using Booking.Services.Data;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Reservations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ReservationRoomBindingModel).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BookingDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<BookingUser, IdentityRole>(
                    options =>
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = false;
                    }).AddEntityFrameworkStores<BookingDbContext>()
                    .AddDefaultTokenProviders()
                    .AddDefaultUI(UIFramework.Bootstrap4);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Data repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddScoped<IPeriodsService, PeriodsService>();
            services.AddScoped<IReservationsService, ReservationsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var dbContext = serviceScope.ServiceProvider.GetRequiredService<BookingDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new BookingDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
