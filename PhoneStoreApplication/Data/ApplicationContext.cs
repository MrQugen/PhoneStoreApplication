using Microsoft.EntityFrameworkCore;
using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {  }

        DbSet<Phone> Phones { get; set; }

        DbSet<PhoneBrand> Brands { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderItems> OrdersItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
