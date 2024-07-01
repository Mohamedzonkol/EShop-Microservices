namespace Basket.Api.Basket.DeleteBasket
{
    public class DeleteBasketValidtors : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketValidtors()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty");
        }
    }
}
