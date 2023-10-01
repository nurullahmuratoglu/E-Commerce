using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Shared.ResponseDtos;
using MediatR;

namespace E_Commerce.Application.Features.Command.Cart.CreateCart
{
    public class CreateCarttCommandRequest : IRequest<ResponseDto<CreateCartViewDto>>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
    }
}
