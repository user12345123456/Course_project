using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess.Configuration;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess
{
    public class ZakazObedov1DBContext : DbContext
    {
        public ZakazObedov1DBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
        }
    }
}