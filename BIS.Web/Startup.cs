using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BIS.DAL.EF;
using BIS.Model.DataModels;
using System.Net.Mail;
using System.Net;
using BIS.Services.Interfaces;
using BIS.Services.Services;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using BIS.Web.Controllers;

namespace BIS.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ApplicationDbContext>(options 
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<UserManager<User>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient(typeof(ILogger), typeof(Logger<Startup>));
            services.AddTransient<IStringLocalizer, StringLocalizer<BaseController>>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IBloodGroupService, BloodGroupService>();
            services.AddScoped((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<string>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                            config.GetValue<string>("Email:Smtp:Username"),
                            config.GetValue<string>("Email:Smtp:Password")
                        )
                };
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { 
                    new CultureInfo("en"), 
                    new CultureInfo("tr-TR") 
                }; 
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"); 
                options.SupportedCultures = supportedCultures; 
                options.SupportedUICultures = supportedCultures;
            }); 
            services.AddLocalization(options => options.ResourcesPath = "Resources"); 
            services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>(); 
            app.UseRequestLocalization(localizationOption.Value); 
            app.UseEndpoints (endpoints => { 
                endpoints.MapControllerRoute (
                    name: "default", 
                    pattern: "{controller=Donor}/{action=Index}/{id?}"); 
                endpoints.MapRazorPages (); 
            });
        }
    }
}