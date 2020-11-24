namespace SnkrsBank.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using SnkrsBank.Domain.Common.Repositories;
    using SnkrsBank.Domain.Data;
    using SnkrsBank.Domain.Data.Repositories;
    using SnkrsBank.Domain.Data.Seeding;
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Services.Contracts;
    using SnkrsBank.Services.Identity;
    using SnkrsBank.Services.Implementation;
    using SnkrsBank.Web.App_Start;
    using SnkrsBank.Web.ViewModels.Account;

    using System.Reflection;

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
            services.AddDbContext<SnkrsBankDbContext>(
                options =>
                {
                    options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews(); services
                 .AddIdentity<User, UserRole>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequiredLength = 8;
                     options.SignIn.RequireConfirmedEmail = true;
                     options.User.RequireUniqueEmail = true;
                     options.Lockout.MaxFailedAccessAttempts = 5;
                     options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(30);
                 })
                 .AddEntityFrameworkStores<SnkrsBankDbContext>()
                 .AddUserStore<ApplicationUserStore>()
                 .AddRoleStore<ApplicationRoleStore>()
                 .AddUserManager<ApplicationUserManager<User>>()
                 .AddSignInManager<ApplicationSignInManager<User>>()
                 .AddDefaultTokenProviders();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                });

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.Lax;
                    options.ConsentCookie.Name = ".AspNetCore.ConsentCookie";
                });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = System.TimeSpan.FromHours(1);
            });

            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            //services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

            // Identity stores
            services.AddTransient<IUserStore<User>, ApplicationUserStore>();
            services.AddTransient<IRoleStore<UserRole>, ApplicationRoleStore>();

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(LoginVIewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<SnkrsBankDbContext>();

                dbContext.Database.Migrate();

                SnkrsBankDbContextSeeder.Seed(dbContext, serviceScope.ServiceProvider);
            }

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

            app.UseStaticFiles();

            app.UseCookiePolicy();

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
