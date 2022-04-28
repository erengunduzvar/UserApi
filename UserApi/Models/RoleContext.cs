using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models
{
    public class RoleContext : DbContext
    {
        public RoleContext(DbContextOptions<RoleContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Role> Roles { get; set; }
    }
}
