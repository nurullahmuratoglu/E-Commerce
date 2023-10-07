using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Application.Features.Command.Cart.AddCartItem;
using E_Commerce.Application.Features.Command.Cart.RemoveCartItem;
using E_Commerce.Application.Features.Command.Cart.UpdateCartProduct;
using E_Commerce.Application.Features.Queries.Cart.GetCartById;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddCartItem([FromBody] AddCartItemCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet]
        public async Task<ResponseDto<CartViewDto>> GetCartById([FromQuery] GetCartByIdQueryRequest request)
        {

            return await _mediator.Send(request);
        }
        [HttpPut]

        public async Task<ResponseDto<NoContentDto>> UpdateCartItem([FromBody] UpdateCartItemCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseDto<NoContentDto>> RemoveCartItem([FromQuery] RemoveCartItemCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
