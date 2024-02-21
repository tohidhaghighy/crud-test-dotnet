using Carter;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Command
{
    public static class AddCustomer
    {
        public class Query : IRequest<object>
        {
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
                    var customer = new Domain.Entities.Customer.Customer
                        (
                        PhoneNumber.Create(request.PhoneNumber),
                        Email.Create(request.Email),
                        BankAccountNumber.Create(request.AccountNumber),
                        new Domain.Entities.Customer.CustomerInfo(request.Firstname, request.Lastname, request.DateOfBirth)
                        );

                    result = await customerService.AddAsync(customer);
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

    public class AddCustomerModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                    $"api/AddCustomer",
                    async (IMediator mediator, [AsParameters] AddCustomer.Query query,
                        CancellationToken cancellationToken) =>
                    {
                        var result = await mediator.Send(query, cancellationToken);
                        return TypedResults.Ok(result);
                    })
                //.RequireAuthorization()
                .WithOpenApi()
                .WithTags("Customer")
                .Produces<object>();
        }
    }
}
