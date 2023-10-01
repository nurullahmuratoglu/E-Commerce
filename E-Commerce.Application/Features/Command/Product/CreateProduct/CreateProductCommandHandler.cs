using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public CreateProductCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException("Kategori bulunamadı.");
            }
            
            category.AddProduct(request.Name, request.Price,request.Stock);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
