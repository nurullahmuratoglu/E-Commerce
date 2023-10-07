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
            var cart = await _context.Carts
                .Where(x => (request.GuestId != null && x.GuestId == request.GuestId) || (request.UserId != null && x.UserId == request.UserId))
                .Where(x => x.IsActive == true)
                .Include(x => x.Items)
                .FirstOrDefaultAsync();

            if (cart == null) throw new NotFoundException("sepet bulunamadı");
            if (!_context.Users.Any(x => x.Id == cart.UserId && x.IsActive == true)&&request.UserId!=null) throw new NotFoundException("kullanıcı aktif değil ");



            var product = await _context.Products.Where(x => x.Id == request.ProductId && x.IsActive == true).FirstOrDefaultAsync();

            if (product == null) throw new NotFoundException("product bulunamadı");

            if (product.Stock == 0) throw new NotFoundException("Stoğu 0 olan ürünü sepete ekleyemezsin");

            cart.AddItem(product.Id, product.Name, product.Price, product.Stock, request.Quantity);
            await _context.SaveChangesAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
