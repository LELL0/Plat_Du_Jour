
using LearningIdentity.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL;
using PlatDuJour.DAL.Models;
using PlatDuJour.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningIdentity
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
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("default")); });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = FBVM.AppId;
                options.AppSecret = FBVM.AppSecret;
            }).AddGoogle(option =>
            {
                //https://console.cloud.google.com/apis/credentials/oauthclient/
                option.ClientId = "680500413509-k30jbehi0k26kd84tdcitspstdeqgqkr.apps.googleusercontent.com";
                option.ClientSecret = "yJaov2gvCaJIncBByLXcn2kQ";
                option.CallbackPath = "/Account/ExternalLoginCallBack/";
            });


            //services.InjectServices();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IQueryFilter, QueryFilter>();
            services.AddScoped<SelectLists>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

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

//first we have to dowload:
/*
 * 1- EntityFrameworkCore => providing the entityframework
 * 2- EntityFrameworkCore.SQLServer => connection and executing on a databaase of type mssql
 * 3- EntityFrameworkCore.Tools => for migration and update-database
 * 4- ASPNetCore.Identity => for authentication and authorizatrion basis
 * 5 - Microsoft.AspNetCore.Identity.EntityFrameworkCore
 * 
 * 
 * startup.cs 
 * 1- configuiation function  => UseAuthentication
 * 2- make sure to put the authentication before authorization
 * 
 * appsettings.json :
 * 1- add the connection string to the database
 * 
 * create folder Data
 * 1 - create new class for applicationDbCotnext that inherits from IdentityDbContext
 * 2- add the ApplicationDbContext service in startup.cs 
 * 
 * Inside Model Folder
 * 1- create a class of ApplicationUser that inherits from IdentityUser
 * 2- inside this class we can add additional properties
 * 
 * Inside Startup.cs
 * 1- Add IdentityService and let it use the entityFrameworkStore to save the registration information inside our database
 * 
 * Inside ApplicationDbcontext
 * 1- Add DbSet<ApplicationUSer>
 * 2 - add-migration 
 * 3- update-databae
 * 
 * Inside Controller Folder
 * 1- create a new controller => AccountController 
 * 2 - add UserManager , SignManager, RoleManager as injected services inside my controller.
 * 
 * Inside ViewModel Folder
 * 1 -Create ViewModel for registration RegisterVM
 * 
 * Inside Views=> _ViewImports Add @using LearningIdentity.ViewModel => to become able of calling the classes directly 
 * FOR REGISTRATION
 * Create ACtionResilt inside the accountController Register()
 * Create View for the Register action controller "do not forget to add the script off _ValidationScriptsPartial"
 * Create HttpPost method for register
 * 
 * FOR LOGIN 
 * Create action result httpget in account Controller 
 * Create viewmodel for Login LoginVM 
 * Create HttpPost for Login 
 * 
 * Create a partial View inside Shared Folder _loginCustom and insert inside it two button based on authentication (login&register)||(welcome&&logout)
 * 
 * 
 * EXTERNAL LOGINS
 * 1- Install Microsoft.AspNetCore.Authentication.Facebook 
 * 2 - go to startup.cs and add facebook authentication 
 * 3 -go to developer.facebook website and create an application to get its applicationId and Application secret then copy them inside the
 * authentication of the facebook while adding the service
 * 4 - Go to Login
 * 
 * **/
