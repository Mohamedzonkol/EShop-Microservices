namespace Basket.Api.Basket.StoreBasket
{
    public class StoreBasketValidtors : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketValidtors()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Cart.Items).Must(x => x.Count > 0).WithMessage("Cart should have atleast one item");
        }
    }
}
