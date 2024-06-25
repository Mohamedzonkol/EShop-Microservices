using MediatR;

namespace CatlogApi.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : IRequest<CreateProductResponse>;
    //Command
    public record CreateProductResponse(Guid Id);//Result
    internal class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
