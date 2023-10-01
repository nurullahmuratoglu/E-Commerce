using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Command.Cart.RemoveCartItem
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public RemoveCartItemCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(RemoveCartItemCommandRequest request, CancellationToken cancellationToken)
        {

            var cart = await _context.Carts.Where(x => x.Id == request.CartId&&x.IsActive==true).Include(x => x.Items).FirstOrDefaultAsync();
            if (cart == null)
            {
                throw new NotFoundException("cart id bulunamadı");

            }
            
            var cartıtem = cart.Items.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (cartıtem == null)
            {
                throw new NotFoundException("product id bulunamadı");
            }
            cart.RemoveItem(request.ProductId);
            if (cart.Items.Count == 0)
            {
                _context.Carts.Remove(cart);

            }
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
