
using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Application.Dtos.Category;
using E_Commerce.Application.Dtos.Product;
using E_Commerce.Application.Features.Command.Cart.AddCartItem;
using E_Commerce.Application.Features.Command.Cart.CreateCart;
using E_Commerce.Application.Features.Command.Cart.RemoveCartItem;
using E_Commerce.Application.Features.Command.Cart.UpdateCartProduct;
using E_Commerce.Application.Features.Command.Category.CreateCategory;
using E_Commerce.Application.Features.Command.Product.CreateProduct;
using E_Commerce.Application.Features.Command.User.CreateUser;
using E_Commerce.Application.Features.Command.User.UserAuthentication;
using E_Commerce.Application.Features.Queries.Cart.GetCartById;
using E_Commerce.Application.Features.Queries.Category.GetAllCategory;
using E_Commerce.Application.Features.Queries.Product;
using E_Commerce.Application.Features.Queries.Product.GetProductByCategoryId;
using E_Commerce.Application.Features.Queries.Product.GetProductById;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class E_CommerceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public E_CommerceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]

        public async Task<ResponseDto<NoContentDto>> AddCategory([FromBody]CreateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);

        }
        [HttpGet]

        public async Task<ResponseDto<CategoryViewDtos>> GetAllCategory()
        {
            GetAllCategoryQueryRequest request = new();
            return await _mediator.Send(request);
        }
        [HttpPost]

        public async Task<ResponseDto<NoContentDto>> AddProduct([FromBody]CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet]
        public async Task<ResponseDto<ProductInfoDto>> GetProductById([FromQuery]GetProductByIdQueryRequest request)
        {

            return await _mediator.Send(request);
        }
        [HttpGet]

        public async Task<ResponseDto<List<ProductInfoDto>>> GetProductByCategoryId([FromQuery]GetProductByCategoryIdQueryRequest request)
        {

            return await _mediator.Send(request);
        }
        [HttpPost]

        public async Task<ResponseDto<CreateCartViewDto>> CreateCart([FromBody] CreateCarttCommandRequest request)
        {
            return await _mediator.Send(request);
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
        [HttpPost]

        public async Task<ResponseDto<NoContentDto>> UpdateCart([FromBody]UpdateCartItemCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]

        public async Task<ResponseDto<NoContentDto>> RemoveCartItem([FromQuery] RemoveCartItemCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]

        public async Task<ResponseDto<NoContentDto>> CreateUser([FromBody]CreateUserCommandRequest request)
        {
            return await _mediator.Send(request);

        }

        [HttpPost]

        public async Task<ResponseDto<NoContentDto>> Login([FromBody]UserAuthQueryRequest request)
        {
            return await _mediator.Send(request);
        }



    }
}