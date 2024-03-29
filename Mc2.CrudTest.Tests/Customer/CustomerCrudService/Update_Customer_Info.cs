﻿using System;
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
    public class Update_Customer_Info: InMemoryRequestDbFixture
    {
        [Fact]
        public async Task UpdateCustomerInfo()
        {
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

            var customer = await service.UpdateAsync(data);

            // Assert
            Assert.NotNull(customer);
        }
    }
}
