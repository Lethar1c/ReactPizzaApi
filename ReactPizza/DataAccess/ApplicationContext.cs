using Microsoft.EntityFrameworkCore;
using ReactPizza.DataAccess.Models;

namespace ReactPizza.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) :
            base(contextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
