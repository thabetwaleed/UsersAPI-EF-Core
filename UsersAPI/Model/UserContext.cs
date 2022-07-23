using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Model
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User>  users { get; set; }


    }
}
