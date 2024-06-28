namespace CatlogApi.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category Is Required");
            // RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image Is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Is Required");
        }
    }
}
