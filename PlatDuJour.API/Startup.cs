
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAPI
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    //Issuer is the API client 
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44330",

                    //Audience is the client 
                    ValidateAudience = true,
                    ValidAudience="https://localhost:44330",

                    ValidateIssuerSigningKey = true,
                    //Our Secret Key
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("here we have to add a key that is larger than 16 characters")),

                    //for delaying the expiry  date of the token
                    ClockSkew = TimeSpan.FromMinutes(0)
                };
            });



            services.AddScoped<IQueryFilter, QueryFilter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));


            services.AddControllers();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //add authentication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


/*1- install system.IdentityModel.Token.JWT
 *2- Install Microsoft.AspNetCore.Authentication.JwtBearer
 * 3 -inside configure method of startup.cs add app.UseAuthentication 
 * (remark: make sure to add it before authorization)
 * 4 - inside configure services add services for authentication and set the default scheme to jwtTokenBearer
 * 5 - set the configuration for the jwtTokenBearer 
 *      a - Valid Issuer => our aplication 
 *      b - Valid Audience => client
 *      c - Create secret key for signature
 *     
 *6 - create accountController and create action method for register and signIn
 *
 * 
 * 
 * 
 * 
 * **/