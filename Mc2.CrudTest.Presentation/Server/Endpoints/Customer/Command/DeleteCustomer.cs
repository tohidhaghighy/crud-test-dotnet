using Carter;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Command
{

    public static class DeleteCustomer
    {
        public class Query : IRequest<object>
        {
            public Guid Id { get; set; }
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
                bool result = new();
                try
                {
                    var customer = await customerService.GetAsync(a => a.Id == request.Id);
                    result = await customerService.DeleteAsync(customer);
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

    public class DeleteCustomerModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                    $"api/DeleteCustomer",
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
