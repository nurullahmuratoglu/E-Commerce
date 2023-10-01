using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Cart.RemoveCartItem
{
    public class RemoveCartItemCommandRequest:IRequest<ResponseDto<NoContentDto>>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
