using ARMS.Models;
using ARMS_BLL;
using CORE_BOL;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL.Entities;
using CORE_DLL;
using EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS
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
            var dt =( DateTime.Today - Convert.ToDateTime("2021-05-01")).Days;
            services.AddDbContext<tt_dbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("ThromdeDbConnection")));

            string connectionString = Configuration.GetConnectionString("ThromdeDBConnection");
            services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));
            services.Configure<DatahubSettings>(Configuration.GetSection("DataHubSettings"))
                .AddSingleton<ITokenService, DatahubTokenService>();

            //.AddTransient<APIServiceBLL, APIServiceBLL>();

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();
            services.Configure<G2CAPISettings>(Configuration.GetSection("G2CAPISettings"))
             .AddSingleton<IG2CTokenService, G2CTokenService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);

                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
               
            });
            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);


            services.AddTransient<IUser, UserBLL>();
            var config = new AutoMapper.MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile()); });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //
            //app.UseSession();
            services.AddMvc();
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); // this code is used to reflect changes in .cshtml page after refreshing.

            services.AddDistributedMemoryCache();
            //MvcOptions.EnableEndpoingRouting = false;
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();
            services.AddSession(opts =>
            {
                //opts.CookieName = ".NetEscapades.Session";
                opts.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            //services.AddControllersWithViews().AddRazorRuntimeCompilation(); // this code is used to reflect changes in .cshtml page after refreshing.
          //email settings
            var emailConfig = Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            //end
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
                //opt.SignIn.RequireConfirmedAccount = false;
            })
 .AddEntityFrameworkStores<AppDBContext>()
 .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/account/login";
                options.LogoutPath = $"/account/logout";
                options.AccessDeniedPath = $"/account/accessDenied";
            });
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
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //      name: "areas",
            //      template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            //    );
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
