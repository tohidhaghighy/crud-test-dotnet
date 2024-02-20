using Carter;
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
            

            public Handler(
                
            )
            {
                
            }

            public async Task<object> Handle(Query request, CancellationToken ct)
            {
                
                var msg = "Ok";
                var isSuccessful = true;
                List<string?[]> result = new();

                
                return new { data = result, msg, success = isSuccessful, total = result.Count };
            }
        }
    }

    public class GetAllCustomersModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                    $"api/OrderHistory",
                    async (IMediator mediator, [AsParameters] GetAllCustomers.Query query,
                        CancellationToken cancellationToken) =>
                    {
                        var result = await mediator.Send(query, cancellationToken);
                        return TypedResults.Ok(result);
                    })
                .RequireAuthorization()
                .WithOpenApi()
                .WithTags("")
                .Produces<object>();
        }
    }
}
