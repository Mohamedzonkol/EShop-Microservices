using BuildingBlocks.CQRS;
using Ordering.Applecation.Data;

namespace Ordering.Applecation.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IAppDbContext context) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            //create Order entity from command object
            //save to database
            //return result 

            var order = CreateNewOrder(command.Order);

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id.Value);
        }

    }
}
