using E_Commerce.Application.Dtos.Product;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Mapping;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Application.Features.Queries.Product.GetProductByCategoryId
{
    public class GetProductByCategoryIdQueryHandler : IRequestHandler<GetProductByCategoryIdQueryRequest, ResponseDto<List<ProductInfoDto>>>
    {
        private readonly E_CommerceDbContext _context;

        public GetProductByCategoryIdQueryHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<ProductInfoDto>>> Handle(GetProductByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (!_context.Categories.Any(x => x.Id == request.CategoryId))
            {
                throw new NotFoundException("kategori bulunamadı");
            }
            var allProducts = new List<ProductInfoDto>();

            await RecursivelyGetProducts(request.CategoryId, allProducts);

            return ResponseDto<List<ProductInfoDto>>.Success(StatusCodes.Status200OK, allProducts);
        }

        private async Task RecursivelyGetProducts(int categoryId, List<ProductInfoDto> productDtos)
        {
            var category = await _context.Categories.Include(x => x.Products.Where(x=>x.IsActive==true)).FirstOrDefaultAsync(x => x.Id == categoryId);


            var mappedProductDtos = ObjectMapper.Mapper.Map<List<ProductInfoDto>>(category.Products);
            productDtos.AddRange(mappedProductDtos);

            var subcategories = await _context.Categories
                .Where(c => c.ParentCategoryID == categoryId)
                .ToListAsync();

            foreach (var subcategory in subcategories)
            {
                await RecursivelyGetProducts(subcategory.Id, productDtos);
            }

        }
    }
}
