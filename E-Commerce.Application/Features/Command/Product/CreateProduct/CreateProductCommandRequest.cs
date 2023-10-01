using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
