using DemoTest001.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoTest001.DataAccess.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
    }
}
