using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Services.Services;
using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Tests.Fixtures;

namespace Mc2.CrudTest.Tests.Customer.CustomerCrudService
{
    public class Delete_Exists_Customer: InMemoryRequestDbFixture
    {
        [Fact]
        public async Task DeleteExistsCustomer()
        {
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+989144967941"),
                        Email.Create("soshyant@gmail.com"),
                        BankAccountNumber.Create("3333333333333"),
                        new Domain.Entities.Customer.CustomerInfo("tohid", "haghighi", DateTime.Now)
                        );
            var service = new CustomerService(DbContext);

            // Act

            var customer = await service.DeleteAsync(data);

            // Assert
            Assert.True(customer);

        }

    }
}
