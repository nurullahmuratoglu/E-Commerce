using E_Commerce.Application.Dtos.Category;
using E_Commerce.Application.Dtos.Product;
using E_Commerce.Application.Features.Command.Category.CreateCategory;
using E_Commerce.Application.Features.Queries.Category.GetAllCategory;
using E_Commerce.Application.Features.Queries.Product.GetProductByCategoryId;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDto<NoContentDto>> AddCategory([FromBody] CreateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);

        }
        [HttpGet]
        public async Task<ResponseDto<CategoryViewDtos>> GetAllCategory()
        {
            return await _mediator.Send(new GetAllCategoryQueryRequest());
        }
        [HttpGet("{categoryid}/products")]
        public async Task<ResponseDto<List<ProductInfoDto>>> GetProductByCategoryId(int categoryid)
        {

            return await _mediator.Send(new GetProductByCategoryIdQueryRequest { CategoryId = categoryid });
        }
    }
}
