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
    public class CustomerService_AddCustomer_InValideAccountNumber_Failure: InMemoryRequestDbFixture
    {
        [Fact]
        public async Task CustomerServiceAddCustomerInValideAccountNumberFailure()
        {
            bool valid = true;
            
            try
            {
                // Arrange
                var data = new Domain.Entities.Customer.Customer
                            (
                            PhoneNumber.Create("+989144967941"),
                            Email.Create("test@gmail.com"),
                            BankAccountNumber.Create("23-34"),
                            new Domain.Entities.Customer.CustomerInfo("test", "test", DateTime.Now)
                            );
                var service = new CustomerService(DbContext);

                // Act

                var customer = await service.AddAsync(data);
            }
            catch (Exception ex)
            {
                valid = false;
            }

            // Assert
            Assert.False(valid);

        }
    }
}
