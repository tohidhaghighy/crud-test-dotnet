using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Mc2.CrudTest.Tests.Fixtures;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Services.Services;

namespace Mc2.CrudTest.Tests.Customer.CustomerCrudService
{
    public class Get_Customer_List: InMemoryRequestDbFixture
    {
        [Fact]
        public async Task GetCustomerList()
        {
            // Arrange

             var service = new CustomerService(DbContext);

            // Act
            var customer = await service.GetAsync(a=>a.Email.email!="");

            // Assert
            Assert.NotNull(customer);

        }
    }
}
