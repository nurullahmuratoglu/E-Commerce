using E_Commerce.Application.Dtos.Product;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Mapping;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ResponseDto<ProductInfoDto>>
    {
        private readonly E_CommerceDbContext _context;

        public GetProductByIdQueryHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<ProductInfoDto>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Include(x=>x.Products)
                .Where(c => c.Products.Any(p => p.Id == request.ProductId&& p.IsActive==true))
                .FirstOrDefaultAsync();
            if (category == null)
            {
                throw new NotFoundException("product id bulunamadı");
            }
            var productCategory = category.Products.FirstOrDefault(x=>x.Id==request.ProductId);


            var productdto=ObjectMapper.Mapper.Map<ProductInfoDto>(productCategory);
            productdto.CategoryName=category.Name;
            return ResponseDto<ProductInfoDto>.Success(StatusCodes.Status200OK,productdto);

        }
    }
}
