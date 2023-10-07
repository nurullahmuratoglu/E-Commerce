using E_Commerce.Application.Dtos.Product;
using E_Commerce.Application.Features.Command.Product.CreateProduct;
using E_Commerce.Application.Features.Queries.Product.GetProductByCategoryId;
using E_Commerce.Application.Features.Queries.Product.GetProductById;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddProduct([FromBody] CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<ProductInfoDto>> GetProductById([FromRoute]int id)
        {
            return await _mediator.Send(new GetProductByIdQueryRequest {ProductId=id });
        }

    }
}
