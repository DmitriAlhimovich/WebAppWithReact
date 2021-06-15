using Microsoft.EntityFrameworkCore;

namespace WebAppWithReact.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
