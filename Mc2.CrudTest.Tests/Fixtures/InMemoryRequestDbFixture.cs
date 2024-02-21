using Azure;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Tests.Fixtures
{
    public class InMemoryRequestDbFixture : IDisposable
    {
        protected readonly CustomerDbContext DbContext;

        public InMemoryRequestDbFixture()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase($"RequestDb-{Guid.NewGuid()}")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            DbContext = new CustomerDbContext(options);
            DbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+989144967941"),
                        Email.Create("soshyant@gmail.com"),
                        BankAccountNumber.Create("3333333333333"),
                        new Domain.Entities.Customer.CustomerInfo("tohid", "haghighi", DateTime.Now)
                        );
            DbContext.Customers.Add(data);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}
