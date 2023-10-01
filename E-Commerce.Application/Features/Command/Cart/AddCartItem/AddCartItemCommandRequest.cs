using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Cart.AddCartItem
{
    public class AddCartItemCommandRequest:IRequest<ResponseDto<NoContentDto>>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
