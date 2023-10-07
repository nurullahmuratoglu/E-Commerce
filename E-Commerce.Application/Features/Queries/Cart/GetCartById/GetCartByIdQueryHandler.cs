using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Mapping;
using E_Commerce.Shared;
using E_Commerce.Shared.ResponseDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.Queries.Cart.GetCartById
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQueryRequest, ResponseDto<CartViewDto>>
    {
        private readonly E_CommerceDbContext _context;

        public GetCartByIdQueryHandler(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CartViewDto>> Handle(GetCartByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts
                .Where(x => (request.GuestId != null && x.GuestId == request.GuestId) || (request.UserId != null && x.UserId == request.UserId))
                .Where(x => x.IsActive == true)
                .Include(x => x.Items)
                .FirstOrDefaultAsync();
            if (cart == null) throw new NotFoundException("sepet bulunamadı");
            if (!_context.Users.Any(x => x.Id == cart.UserId && x.IsActive == true) && request.UserId != null) throw new NotFoundException("kullanıcı aktif değil ");



            var cartDto = ObjectMapper.Mapper.Map<CartViewDto>(cart);

            cartDto.TotalPrice = cart.CalculateTotalPrice();

            return ResponseDto<CartViewDto>.Success(StatusCodes.Status200OK, cartDto);


        }
    }
}
