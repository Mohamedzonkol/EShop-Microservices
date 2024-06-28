namespace CatlogApi.Products.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Product ID Is Required");
        }
    }
}
