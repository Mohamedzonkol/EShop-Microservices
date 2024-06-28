namespace CatlogApi.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Required")
                .Length(2, 150).WithMessage("Length Must be between 2 to 150 char ");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category Is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image Is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Is Required");
        }
    }
}
