using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Services.Services;
using Mc2.CrudTest.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Tests.Customer.CustomerBusinessService
{
    public class CustomerService_AddCustomer_InValideEmail_Failure : InMemoryRequestDbFixture
    {
        [Fact]
        public async Task CustomerServiceAddCustomerInValideEmailFailure()
        {
            // Arrange
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+989144967941"),
                        Email.Create("444.com"),
                        BankAccountNumber.Create("3333333333333"),
                        new Domain.Entities.Customer.CustomerInfo("tohid1", "haghighi2", DateTime.Now)
                        );
            var service = new CustomerService(DbContext);

            // Act

            var customer = await service.AddAsync(data);

            // Assert
            Assert.NotNull(customer.Id);

        }
    }
}
