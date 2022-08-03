using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsersAPI.Helpers;
using UsersAPI.Model;
using UsersAPI.Repos;

namespace UsersAPI.Extensions
{
    public static class MyExtensions
    {
        public static void myser(this IServiceCollection serobj, ConfigurationManager conf)
        {

            serobj.AddDbContext<UserContext>(d => d.UseSqlServer(conf.GetConnectionString("ConnectionString1")));
            serobj.AddScoped<INewUserRepo, NewUserRepo>();
            serobj.AddScoped<INewPostRepo, NewPostRepo>();

            serobj.Configure<JWT>(conf.GetSection("JWT"));  //this will map the values in appsittings with JWT class

            // For Identity
            serobj.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            serobj.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             })

                
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = conf["JWT:ValidAudience"],
                     ValidIssuer = conf["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JWT:Secret"]))
                 };
             });

           
        }
    }
}
