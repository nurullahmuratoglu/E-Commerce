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
            var product = await _context.Products.Where(x => x.Id == request.ProductId).Include(x => x.Category).FirstOrDefaultAsync();
            if (product == null) throw new NotFoundException("id bulunamadı");



            if (product.IsActive == false) throw new NotFoundException("ürün yayında değil");



            var productdto = ObjectMapper.Mapper.Map<ProductInfoDto>(product);

            return ResponseDto<ProductInfoDto>.Success(StatusCodes.Status200OK, productdto);

        }
    }
}
