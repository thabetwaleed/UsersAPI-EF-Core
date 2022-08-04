using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Model
{
    public class UserContext:IdentityDbContext<User,UserRole,int>
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
        }

        public DbSet<User>  User { get; set; }
        public DbSet<Post> Post { get; set; }
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //}
}
