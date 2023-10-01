using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Command.Cart.AddCartItem
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public AddCartItemCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(AddCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.Where(x => x.Id == request.CartId && x.IsActive==true).Include(x => x.Items).FirstOrDefaultAsync();
            if (cart == null)
            {
                throw new NotFoundException("cart bulunamadı");
            }
            
            var product = await _context.Categories
    .Where(c => c.Products.Any(p => p.Id == request.ProductId))
    .SelectMany(c => c.Products.Where(p => p.Id == request.ProductId&&p.IsActive==true))
    .FirstOrDefaultAsync();
            if (product == null)
            {

                throw new NotFoundException("product bulunamadı");

            }
            if (product.Stock <= 0)
            {
                throw new NotFoundException("ürünün stock miktarı 0 dan nüyük olmalıdır");

            }

            cart.AddItem(product.Id, product.Name, product.Price, product.Stock, request.Quantity);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
