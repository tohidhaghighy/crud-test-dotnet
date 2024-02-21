using Mc2.CrudTest.Domain.Entities.Customer;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Services.Services;
using Mc2.CrudTest.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Tests.Customer.CustomerBusinessService
{
    public class CustomerService_AddCustomer_InsertUniqueEmail_Success : InMemoryRequestDbFixture
    {
        [Fact]
        public async Task CustomerServiceAddCustomerInsertUniqueEmailSuccess()
        {
            string error_Message = "";
            // Arrange
            var data = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create("+989144967941"),
                        Email.Create("soshyant@gmail.com"),
                        BankAccountNumber.Create("3333333333333"),
                        new Domain.Entities.Customer.CustomerInfo("tohid", "haghighi", DateTime.Now)
                        );
            var service = new CustomerService(DbContext);

            // Act
            try
            {
                var customer = await service.AddAsync(data);
            }
            catch (Exception ex)
            {
                error_Message= ex.Message;
            }

            // Assert
            Assert.NotEqual(error_Message,"");
        }
    }
}
