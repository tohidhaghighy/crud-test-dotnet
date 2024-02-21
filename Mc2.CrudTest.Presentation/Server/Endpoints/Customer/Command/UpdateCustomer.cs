using Carter;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Command
{
    public static class UpdateCustomer
    {
        public class Query : IRequest<object>
        {
            public Guid Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string AccountNumber { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class Handler : IRequestHandler<Query, object>
        {

            private readonly ICustomerService customerService;
            public Handler(
                ICustomerService customerService
            )
            {
                this.customerService = customerService;
            }

            public async Task<object> Handle(Query request, CancellationToken ct)
            {

                var msg = "Ok";
                var isSuccessful = true;
                Domain.Entities.Customer.Customer result = new();
                try
                {
                    var customer = await customerService.GetAsync(a => a.Id == request.Id);
                    customer.SetEmail(Email.Create(request.Email));
                    customer.SetPhoneNumber(PhoneNumber.Create(request.PhoneNumber));
                    customer.SetBankAccountNumber(BankAccountNumber.Create(request.AccountNumber));
                    customer.UpdateInfo(new Domain.Entities.Customer.CustomerInfo(request.Firstname, request.Lastname, request.DateOfBirth));

                    result = await customerService.UpdateAsync(customer);
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    isSuccessful = false;
                }

                return new { data = result, msg, success = isSuccessful };
            }
        }
    }

    public class UpdateCustomerModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                    $"api/UpdateCustomer",
                    async (IMediator mediator, [AsParameters] AddCustomer.Query query,
                        CancellationToken cancellationToken) =>
                    {
                        var result = await mediator.Send(query, cancellationToken);
                        return TypedResults.Ok(result);
                    })
                .WithOpenApi()
                .WithTags("Customer")
                .Produces<object>();
        }
    }
}
