﻿namespace Ordering.Applecation.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order)
        : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);
}
