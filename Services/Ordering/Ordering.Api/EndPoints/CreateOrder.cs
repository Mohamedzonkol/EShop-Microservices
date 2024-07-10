using Carter;
using Mapster;
using MediatR;
using Ordering.Applecation.Dtos;
using Ordering.Applecation.Orders.Commands.CreateOrder;

namespace Ordering.Api.EndPoints
{
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid Id);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest req, ISender sender) =>
            {
                var command = req.Adapt<CreateOrderCommand>();
                var res = await sender.Send(command);
                var response = res.Adapt<CreateOrderResponse>();
                return Results.Created($"/orders/{response.Id}", response);

            }).WithName("CreateOrder")
            .Produces<CreateOrderResponse>(201)
            .ProducesProblem(400)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
        }
    }
}
