using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities.Customer;
using Mc2.CrudTest.Services.Services;
using Mc2.CrudTest.Tests.Fixtures;
using Azure.Core;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Tests.Customer.CustomerCrudService
{
    public class Add_New_Customer: InMemoryRequestDbFixture
    {
        [Fact]
        public async Task AddNewCustomer()
        {
            // Arrange
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+989144967941"),
                        Email.Create("tsoshyant@gmail.com"),
                        BankAccountNumber.Create("3333333333333"),
                        new Domain.Entities.Customer.CustomerInfo("tohid", "haghighi", DateTime.Now)
                        );
            var service = new CustomerService(DbContext);

            // Act

            var customer = await service.AddAsync(data);

            // Assert
            Assert.NotNull(customer.Id);

        }

    }
}
