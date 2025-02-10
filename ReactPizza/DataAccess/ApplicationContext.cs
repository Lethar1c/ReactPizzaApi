using Microsoft.EntityFrameworkCore;

namespace ReactPizza.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) :
            base(contextOptions)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
