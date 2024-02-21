using Carter;
using Mc2.CrudTest.Domain.Entities.Customer;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using MediatR;
using Microsoft.VisualBasic;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Query
{
    public static class GetAllCustomers
    {
        public class Query : IRequest<object>
        {
            public int Skip { get; set; }
            public int Take { get; set; }
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
                List<Domain.Entities.Customer.Customer> result = new();
                try
                {
                    result = await customerService.ListAsync(a => a.Email.email == "");
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    isSuccessful = false;
                }
                
                return new { data = result, msg, success = isSuccessful, total = result.Count };
            }
        }
    }

    public class GetAllCustomersModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                    $"api/GetAll",
                    async (IMediator mediator, [AsParameters] GetAllCustomers.Query query,
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
