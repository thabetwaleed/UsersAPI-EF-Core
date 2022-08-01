using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;
using UsersAPI.Repos;

namespace UsersAPI.Extensions
{
    public static class MyExtensions
    {
        public static void myser( this IServiceCollection serobj ,ConfigurationManager conf)
        {
 
             serobj.AddDbContext<UserContext>(d => d.UseSqlServer(conf.GetConnectionString("ConnectionString1")));
             serobj.AddScoped<INewUserRepo, NewUserRepo>();
             serobj.AddScoped<INewPostRepo, NewPostRepo>();
              



        }
    }
}
