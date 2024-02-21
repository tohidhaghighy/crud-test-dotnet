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
            modelBuilder.Entity<Customer>().OwnsOne(p => p.CustomerInfo).Property(x=>x.FirstName).HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>().OwnsOne(p => p.CustomerInfo).Property(x => x.LastName).HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>().OwnsOne(p => p.Email).Property(x => x.email).HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>().OwnsOne(p => p.BankAccountNumber).Property(x => x.BankAccount).HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>().OwnsOne(p => p.PhoneNumber).Property(x => x.Number).HasColumnType("varchar(13)");
            //modelBuilder.Entity<Customer>().HasKey(c => new { c.CustomerInfo.FirstName, c.CustomerInfo.LastName, c.CustomerInfo.DateOfBirth });
            //modelBuilder.Entity<Customer>().HasKey(c => new { c.Email.email});
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
