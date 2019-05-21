namespace Booking.Web
{
    using AutoMapper;
    using Booking.Data;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Data.Repositories;
    using Booking.Services.Data;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
                //typeof(IndexViewModel).Assembly
            );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BookingDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<BookingUser>(
                    options =>
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = false;
                    }).AddEntityFrameworkStores<BookingDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddAutoMapper();

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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
