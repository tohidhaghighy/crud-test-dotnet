using Mc2.CrudTest.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
      : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().OwnsOne(p => p.CustomerInfo);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.Email);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.BankAccountNumber);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.PhoneNumber);
            modelBuilder.Entity<Customer>().HasIndex(b => new { b.Email }).IsUnique();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
