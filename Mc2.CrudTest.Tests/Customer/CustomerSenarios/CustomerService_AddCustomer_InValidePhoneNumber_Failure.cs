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
    public class CustomerService_AddCustomer_InValidePhoneNumber_Failure : InMemoryRequestDbFixture
    {
        [Fact]
        public async Task CustomerServiceAddCustomerInValidePhoneNumberFailure()
        {
            // Arrange
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+98941"),
                        Email.Create("soshyant@gmail.com"),
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

