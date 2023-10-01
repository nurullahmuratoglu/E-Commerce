using E_Commerce.Application.Exceptions;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Command.Cart.UpdateCartProduct
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly E_CommerceDbContext _context;

        public UpdateCartItemCommandHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UpdateCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.Where(x => x.Id == request.CartId&&x.IsActive==true).Include(x => x.Items).FirstOrDefaultAsync();
            if (cart==null)
            {
                throw new NotFoundException("cart bulunamadı");

            }            
            if (!cart.Items.Any(x => x.ProductId == request.ProductId))
            {
                throw new NotFoundException("ürün bulunamadı");

            }
            cart.UpdateItemQuantity(request.ProductId, request.Quantity);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
