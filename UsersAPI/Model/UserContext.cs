using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Model
{
    public class UserContext:IdentityDbContext<IdentityUser>
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
        }

        public DbSet<User>  users { get; set; }
        public DbSet<Post> posts { get; set; }
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //}
}
